namespace Models.TrainingModel
{
    public class VideoTraining : Training
    {
        public double Rating { get; set; }
        public VideoTraining(int id, string title, DateTime trainingDuration, double rating) : base(id, title, trainingDuration)
        {
            Rating = rating;
        }
    }
}
