namespace UWFoodMenu
{
    public class Meta
    {
        public int requests { get; set; }
        public int timestamp { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public int method_id { get; set; }
        public Method method { get; set; }
    }
}