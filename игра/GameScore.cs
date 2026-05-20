using System.Windows.Forms;

namespace игра
{
    public class GameScore
    {
        private Label scoreLabel;
        private Label recordLabel;
        private int currentScore;
        private int record;
        public int CurrentScore
        {
            get => currentScore;
            private set
            {
                currentScore = value;
                UpdateUI();
            }
        }

        public GameScore(Label scoreLabel, Label recordLabel)
        {
            this.scoreLabel = scoreLabel;
            this.recordLabel = recordLabel;
            currentScore = 0;
            record = 0;
        }
        public void AddScore(int points)
        {
            CurrentScore += points;
            if (CurrentScore > record)
            {
                record = CurrentScore;
                recordLabel.Text = $"Рекорд: {record}";
            }
        }
        public void Reset()
        {
            CurrentScore = 0;
        }
        private void UpdateUI()
        {
            scoreLabel.Text = $"Рыбки: {CurrentScore}";
        }
    }
}