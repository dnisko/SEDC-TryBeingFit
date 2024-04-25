namespace Models.TrainingModel
{
    public class LiveTraining : Training
    {
        public DateTime[] StartEndDate { get; set; }
        public List<int> AvailableDayOfWeek { get; set; }
        public LiveTraining(int id, string title, DateTime trainingDuration, DateTime[] startEndDate, List<int> availableDayOfWeek)
            : base(id, title, trainingDuration)
        {
            StartEndDate = startEndDate;
            AvailableDayOfWeek = availableDayOfWeek;
        }
    }
}
