using System.Configuration;
using System.Drawing.Text;
using System.IO;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Text.RegularExpressions;
using Quiz.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Xml.Linq;

namespace Quiz
{
    public partial class Form1 : Form
    {

        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                Variablen, arrays, Listen und Objekte                     //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        private ReadFile[]? questionAnswer;
        private List<RankingTopten> list;

        private Dictionary<int, string> askedQuestionDictionary;
        private Stack<int> _goBackToLastQuestion;
        private Random rand;

        private Regex _namensRegex;

        private string basePath = @"C:\Users\nico_\Repositories\Quiz";

        private string fileCSharpBasicQuiz => Path.Combine(basePath, "ITFragen.txt");
        private string fileCSharpAdvancedQuiz => Path.Combine(basePath, "CSharpErweitertesWissen.txt");
        private string fileGeneralKnowledgeQuiz => Path.Combine(basePath, "FragenAntworten.txt");
        private string fileSafeUserAnswer => Path.Combine(basePath, "Ergebnisdateien\\ErgebnisQuiz.txt");
        private string fileTopTenHighscore => Path.Combine(basePath, "Ergebnisdateien\\Ranking.txt");


        private string outputCorrectOrIncorrectAnswer = string.Empty;

        private decimal countsCorrectAnswer = 0;
        private decimal countsQuizClicks = 0;
        private decimal aktuellerPlayerProzent = 0;

        // index für die Fragen aus der Datei
        private int i = 0;
        private int x = 1;
        private int randomNumber;
        private int remainingTime = 0;


        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                            Konstruktoren                                 //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();

            _namensRegex = new Regex(@"^[^@#!%,?$&]+$");
        }


        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //         Methoden / Funktionen um das Quiz bereit zu stellen              //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        #region Laden
        /// <summary>
        /// Eine Funktion um zu Beginn die Existenz der Quiz-Dateien zu prüfen
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!File.Exists(fileCSharpBasicQuiz) || !File.Exists(fileGeneralKnowledgeQuiz) || !File.Exists(fileCSharpAdvancedQuiz))
            {
                MessageBox.Show($"Die Dateien für die Quizfragen wurde nicht gefunden", "Fehler!");
                ChangeToSelection();
                Start.Enabled = false;
                AllKnowQuiz.Enabled = false;
                CSharp2.Enabled = false;
                nameBox.Enabled = false;
            }

            rand = new Random();
            askedQuestionDictionary = new Dictionary<int, string>();
            _goBackToLastQuestion = new Stack<int>();
        }
        #endregion

        #region CheckAndLoadTheFile
        /// <summary>
        /// Eine Funktion zur Bereitstellung der Fragen:
        /// Übergebener Dateipfad wird geladen und in ein array mit Objekten 
        /// der Klasse ReadFile gespeichert
        /// </summary>
        /// <param name="filename">Dateipfad als string Variable</param>
        public void CheckAndLoadTheFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            questionAnswer = new ReadFile[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] value = lines[i].Split(';');
                ReadFile answer = new ReadFile();
                answer.Question = value[0];
                answer.AnswerOne = value[1];
                answer.AnswerTwo = value[2];
                answer.AnswerThree = value[3];
                answer.CorrectAnswer = int.Parse(value[4]);

                questionAnswer[i] = answer;
            }
        }
        #endregion

        #region LoadOneQuestionSet
        /// <summary>
        /// Eine Funktion zu Bereitstellung eines Frage-Antwort-Set:
        /// Lädt aus dem array (Klasse ReadFile) ein FragenAntworten Objekt
        /// </summary>
        /// <param name="index">Der Index des Arrays</param>
        public void LoadOneQuestionSet(int index)
        {
            label1.Text = questionAnswer[index].Question;
            Answer1.Text = questionAnswer[index].AnswerOne;
            Answer2.Text = questionAnswer[index].AnswerTwo;
            Answer3.Text = questionAnswer[index].AnswerThree;
        }
        #endregion

        #region LoadRandomDicQuestionSet (noch nicht eingebaut)
        /// <summary>
        /// Eine Rekursive-Funktion um die Fragen nach einem Zufallsprinzip auszuwerfen
        /// </summary>
        /// <returns>int, die Zufallszahl</returns>
        private int LoadRandomDicQuestionSet()
        {
            // if abfrage ob Stack und Dicionary gleich groß sind
            // wenn nicht Dictionary löschen und mit Inhalt vom Stack füllen
           

            // ermittelt eine Zufallszahl
            randomNumber = rand.Next(0, questionAnswer.Length);

            // Es muss geprüft werden, ob sich diese Zahl schon im Dicionary befindet
            // Wenn die Zufallszahl nicht drin ist...
            if (!askedQuestionDictionary.ContainsKey(randomNumber))
            {
                // ...dann trage die Zahl ein und werfe das Fragen-Set aus
                askedQuestionDictionary.Add(randomNumber, "Frage wurde gestellt");
                _goBackToLastQuestion.Push(randomNumber);
                return randomNumber;
            }
            // Wenn die Zahl nicht vorhanden ist...
            else
            {
                // ruft die Funktion sich so lange selber auf, bis eine nicht enthaltene Zahl
                // generiert wurde und wirft diese zurück
                return LoadRandomDicQuestionSet();
            }
        }
        #endregion

        #region CheckNameAndStartTheQuiz
        /// <summary>
        /// Eine Funktion für den Start:
        /// Prüft und schreibt den Namenseintrag und lädt das erste Fragen-Set
        /// </summary>
        public void CheckNameAndStartTheQuiz()
        {
            if (nameBox.Text == string.Empty)
            {
                MessageBox.Show("Bitte zuerst den Namen eintragen.", "Fehler!");
            }
            else if (nameBox.Text == " " || nameBox.Text == "  ")
            {
                MessageBox.Show("Ungültiger Name!", "Fehler!");
            }
            else if (!_namensRegex.IsMatch(nameBox.Text))
            {
                MessageBox.Show("Name beinhaltet ungültige Zeichen!", "Fehler!");
            }
            else if (nameBox.Text.Length > 20)
            {
                MessageBox.Show("Name ist zu lang. Maximal 20 Zeichen!", "Fehler!");
            }
            else
            {
                // mögliche Leerzeichen vor und hinter dem Namen werden gelöscht
                nameBox.Text = nameBox.Text.Trim();
                // Namensfeld wird deaktiviert, damit er nicht verändert werden kann
                nameBox.Enabled = false;

                ButtonVisibleChange();
                ChangeToGame();

                File.WriteAllText(fileSafeUserAnswer, $"Name: {nameBox.Text}\n\n");

                // Einstellung und starten des Timers
                remainingTime = 30;
                timelabel.Text = "30 Sekunden";
                timer1.Start();
            }

            // Funktion in einer Funktion für if-else (nicht nötig, nur als Übung gedacht)
            void ButtonVisibleChange()
            {
                Start.Visible = false;
                AllKnowQuiz.Visible = false;
                CSharp2.Visible = false;
                pictureBox1.Visible = false;
                label4.Visible = false;
            }
        }
        #endregion

        #region CheckAndWriteAnswer
        /// <summary>
        /// Eine Funktion um die Antwort zu prüfen:
        /// Färbt den angeklickten Button rot oder grün, deaktiviert alle Button
        /// und schreibt die Antworten in eine Datei
        /// </summary>
        /// <param name="correctanswer">Antwort-Buttonnummer</param>
        /// <param name="butt1">Korrekte Antwort</param>
        /// <param name="butt2">Falsche Antwort</param>
        /// <param name="butt3">Falsche Antwort</param>
        public void CheckAndWriteAnswer(int correctanswer, Button butt1, Button butt2, Button butt3)
        {
            countsQuizClicks++;

            // wenn die Antwort richtig ist, Button grün und zähler erhöhen
            if (questionAnswer[i].CorrectAnswer == correctanswer)
            {
                butt1.BackColor = Color.LimeGreen;
                countsCorrectAnswer++;
                outputCorrectOrIncorrectAnswer = "Richtig";
            }
            // wenn die Antwort falsch ist, Button rot
            else
            {
                butt1.BackColor = Color.Red;
                outputCorrectOrIncorrectAnswer = "Falsch";
            }

            // Antwortbutton werden deaktiviert, um eine Mehrauswahl oder Umentscheidung zu verhindern
            butt1.Enabled = false;
            butt2.Enabled = false;
            butt3.Enabled = false;

            // Frage mit (Richtig oder Falsch) wird in die Datei angehängt
            File.AppendAllText(fileSafeUserAnswer, $"Frage {i + 1}: {outputCorrectOrIncorrectAnswer}!\t\t\t");
        }
        #endregion

        #region CalculatePercentHighscore
        /// <summary>
        /// Eine Funktion um eine Teilung durch 0 zu verhindern und um das Ergebnis in Prozent auszurechnen
        /// </summary>
        public void CalculatePercentHighscore()
        {
            if (countsQuizClicks == 0)
            {
                countsQuizClicks = 1;
            }
            else
            {
                // Die Prozentzahl des aktuellen Players wird errechnet und auf zwei Nachkommastelle gekürzt
                decimal result = ((countsCorrectAnswer / countsQuizClicks) * (decimal)100);
                aktuellerPlayerProzent = decimal.Round(result, 2);
            }
        }
        #endregion

        #region HighscoreTopTen
        /// <summary>
        /// Eine Funktion um den Highscore (Die Top Ten) zu aktualisieren:
        /// Übergebener Dateipfad wird geladen und in eine Liste mit Objekten 
        /// der Klasse RankingTopten gespeichert
        /// </summary>
        public void HighscoreTopTen()
        {
            // Datei des aktuellen Highscore wird eingelesen jede Zeile in einem index
            string[] lines = File.ReadAllLines(fileTopTenHighscore);    // 11 Indexe

            // leere Liste wird erstellt für alle Highscore Einträge
            list = new List<RankingTopten>();

            CalculatePercentHighscore();

            // Die Zeilen im array werden gesplittet und Leerzeichen getrimmt
            // erste Zeile Überschrift wird ignoriert
            // Die Werte im Index 1 und 2 werden als Objekt gespeichert und der Liste hinzugefügt
            for (int i = 2; i < lines.Length; i++)
            {
                string[] value = lines[i].Split(':');
                RankingTopten rankingTopten = new RankingTopten();
                rankingTopten.Name = value[1].Trim();
                string pro = value[2].Substring(0, value[2].Length - 1);
                string last = pro.Trim();
                var d = decimal.Parse(last);
                rankingTopten.Prozent = decimal.Round(d, 2);

                list.Add(rankingTopten);
            }

            // Aktueller Player wird als Objekt gespeichert und der Liste hinzugefügt
            RankingTopten aktuellerPlayer = new RankingTopten();
            aktuellerPlayer.Name = nameBox.Text;
            aktuellerPlayer.Prozent = aktuellerPlayerProzent;
            list.Add(aktuellerPlayer);

            // Die Liste wird sortiert, umgedreht und die letzte Stelle gelöscht
            list.Sort();
            list.Reverse();
            list.RemoveAt(10);

            File.WriteAllText(fileTopTenHighscore, string.Empty);

            // Die Überschriftzeile aus dem array wird wieder in die Datei gespeichert
            File.WriteAllText(fileTopTenHighscore, lines[0] + Environment.NewLine);
            File.AppendAllText(fileTopTenHighscore, lines[1] + Environment.NewLine);

            // Auslesen der Liste mit allen Einträgen und wieder einfügung in die Datei Angehängt mit Zeilenumbruch
            foreach (RankingTopten player in list)
            {
                string pro = $"{player.Prozent:N2}";
                File.AppendAllText(fileTopTenHighscore, $"{x.ToString().PadLeft(2)} : {player.Name.PadRight(20)}: {pro.PadLeft(6)} %" + Environment.NewLine);
                x++;
            }
        }
        #endregion


        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //            Funktionen die den Status der Button ändern                   //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        #region AnswerButtonActivate
        /// <summary>
        /// Aktiviert die Antwort-Button und setzt die Farbe auf den Startmodus zurück
        /// </summary>
        public void AnswerButtonActivate()
        {
            Answer1.Enabled = true;
            Answer2.Enabled = true;
            Answer3.Enabled = true;
            Answer1.BackColor = Color.WhiteSmoke;
            Answer2.BackColor = Color.WhiteSmoke;
            Answer3.BackColor = Color.WhiteSmoke;
        }
        #endregion

        #region ChangeButtonStatus
        /// <summary>
        /// Button deaktiveren, Neustart+Ergebnis aktivieren
        /// tritt ein wenn spielrunde zuende ist
        /// </summary>
        public void ChangeButtonStatus()
        {
            NextQuestion.Enabled = false;
            QuestionBefore.Enabled = false;
            Answer1.Enabled = false;
            Answer2.Enabled = false;
            Answer3.Enabled = false;
            ShowResult.Enabled = true;
            Highscore.Enabled = true;
            NeuStart.Enabled = true;
        }
        #endregion

        #region ChangeToSelection
        /// <summary>
        /// Eine Funktion um die Sichtbarkeit und Aktivität zu wechseln
        /// Springt zurück zum Anfangsbild, bzw. zur Quizauswahl
        /// </summary>
        public void ChangeToSelection()
        {
            // Die Sichtbarkeit wechseln
            Start.Visible = true;
            CSharp2.Visible = true;
            AllKnowQuiz.Visible = true;
            pictureBox1.Visible = true;

            // Die Aktivität wechseln
            NextQuestion.Enabled = true;
            QuestionBefore.Enabled = true;
            ShowResult.Enabled = false;
            Highscore.Enabled = false;
        }
        #endregion

        #region ChangeToGame
        /// <summary>
        /// Eine Funktion um die Sichtbarkeit der Button zu wechseln
        /// Springt vom Anfangsbild in die QuizOptik
        /// </summary>
        public void ChangeToGame()
        {
            Start.Visible = false;
            CSharp2.Visible = false;
            AllKnowQuiz.Visible = false;
            pictureBox1.Visible = false;
            label4.Visible = false;
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                        Button-Klick Aktionen                             //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        // C# Basic Quiz
        private void Start_Click(object sender, EventArgs e)
        {
            CheckAndLoadTheFile(fileCSharpBasicQuiz);
            CheckNameAndStartTheQuiz();
            LoadOneQuestionSet(0);
            AnswerButtonActivate();
        }


        // C# erweitertes Wissen Quiz
        private void CSharp2_Click(object sender, EventArgs e)
        {
            CheckAndLoadTheFile(fileCSharpAdvancedQuiz);
            CheckNameAndStartTheQuiz();
            LoadOneQuestionSet(0);
            AnswerButtonActivate();
        }

        // Allgemeinwissen Quiz
        private void AllKnowQuiz_Click(object sender, EventArgs e)
        {
            CheckAndLoadTheFile(fileGeneralKnowledgeQuiz);
            CheckNameAndStartTheQuiz();
            LoadOneQuestionSet(0);
            AnswerButtonActivate();
        }

        private void Answer1_Click(object sender, EventArgs e)
        {
            CheckAndWriteAnswer(1, Answer1, Answer2, Answer3);
        }

        private void Answer2_Click(object sender, EventArgs e)
        {
            CheckAndWriteAnswer(2, Answer2, Answer1, Answer3);
        }

        private void Answer3_Click(object sender, EventArgs e)
        {
            CheckAndWriteAnswer(3, Answer3, Answer1, Answer2);
        }

        private void NextQuestion_Click(object sender, EventArgs e)
        {
            AnswerButtonActivate();

            // Prüfung ob noch eine Frage vorhanden ist
            if (i < questionAnswer.Length - 1)
            {
                i++;
                LoadOneQuestionSet(i);
                Highscore.Enabled = false;
                ShowResult.Enabled = false;
            }
            // Wenn keine Frage mehr da ist, Spiel beenden
            else
            {
                timer1.Stop();
                MessageBox.Show($"Das war die letzte Frage!\nSie haben {countsCorrectAnswer} von {countsQuizClicks} Fragen richtig.", "Sorry!");
                ChangeButtonStatus();
                HighscoreTopTen();

                Highscore.Enabled = true;
                ShowResult.Enabled = true;
                QuestionBefore.Enabled = true;
            }
        }

        private void QuestionBefore_Click(object sender, EventArgs e)
        {
            AnswerButtonActivate();

            // sprung zurück zur vorherigen Frage solange i größer als 0 ist
            if (i > 0)
            {
                i--;
                LoadOneQuestionSet(i);
                NextQuestion.Enabled = true;
                Highscore.Enabled = false;
                ShowResult.Enabled = false;
            }
            // sobald i = 0 ist, sind keine Fragen mehr vorhanden
            else
            {
                timer1.Stop();
                MessageBox.Show($"Zurückspringen nicht möglich.\nDies ist die erste Frage.", "Fehler!");
                timer1.Start();
            }
        }

        private void ShowResult_Click(object sender, EventArgs e)
        {
            //string datei = File.ReadAllText(fileSafeUserAnswer);
            //MessageBox.Show(datei, "Ihr Ergebnis");

            label4.Visible = true;
            label4.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);

            // Wenn die Ergebnis-Datei nach einem Neustart leer sein sollte
            try
            {
                label4.Text = File.ReadAllText(fileSafeUserAnswer);
            }
            catch
            {
                label4.Text = "Kein Ergebnis vorhanden";
            }
        }

        private void Highscore_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            label4.Text = File.ReadAllText(fileTopTenHighscore);
            label4.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        private void NeuStart_Click(object sender, EventArgs e)
        {
            remainingTime = 30;
            timelabel.Text = "30 Sekunden";
            timer1.Start();

            AnswerButtonActivate();
            LoadOneQuestionSet(0);
            NextQuestion.Enabled = true;
            ShowResult.Enabled = false;
            Highscore.Enabled = false;

            // clear
            File.Delete(fileSafeUserAnswer);
            countsCorrectAnswer = 0;
            countsQuizClicks = 0;
            i = 0;
        }

        private void QuizSelection_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            ChangeToSelection();
            label4.Visible = false;

            countsCorrectAnswer = 0;
            countsQuizClicks = 0;
            i = 0;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                timelabel.Text = $"{remainingTime} Sekunden";
            }
            else
            {
                timer1.Stop();
                timelabel.Text = "Die Zeit ist um";
                MessageBox.Show($"Die Zeit ist abgelaufen!\nSie haben {countsCorrectAnswer} von {countsQuizClicks} Fragen richtig.", "Time Over!");

                ChangeButtonStatus();
                Highscore.Enabled = true;
                ShowResult.Enabled = true;

                HighscoreTopTen();
            }
        }
    }
}
