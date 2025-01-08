using GraphqlHello.Model;

namespace GraphqlHello.Helper
{
    public static class DataStore
    {
        private static List<ChartData> _chartDataList = new List<ChartData>();

        static DataStore()
        {
            for (int i = 0; i < 5000; i++)
            {
                _chartDataList.Add(new ChartData
                {
                    Id = i,
                    Label = $"Data {i}",
                    Points = GenerateRandomIntArray(8)
                });
            }
        }

        private static int[] GenerateRandomIntArray(int length)
        {
            Random random = new Random();
            int[] randomArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                randomArray[i] = random.Next(0, 3); // Gera números aleatórios entre 0 e 3
            }

            return randomArray;
        }

        // Method to add ChartData
        public static void AddChartData(ChartData chartData)
        {
            _chartDataList.Add(chartData);
        }

        // Method to delete ChartData by Id
        public static bool DeleteChartData(int id)
        {
            var chartData = _chartDataList.FirstOrDefault(cd => cd.Id == id);
            if (chartData != null)
            {
                _chartDataList.Remove(chartData);
                return true;
            }
            return false;
        }

        // Method to list all ChartData
        public static List<ChartData> GetAllChartData()
        {
            return _chartDataList;
        }

        // Method to update Points of ChartData by Id
        public static bool UpdateChartDataPoints(int id, int[] newPoints)
        {
            var chartData = _chartDataList.FirstOrDefault(cd => cd.Id == id);
            if (chartData != null)
            {
                chartData.Points = newPoints;
                return true;
            }
            return false;
        }

        // Method to update random Points of ChartData by Id
        public static bool UpdateChartDataPointsRandon(int id)
        {
            var chartData = _chartDataList.FirstOrDefault(cd => cd.Id == id);
            if (chartData != null)
            {
                chartData.Points = GenerateRandomIntArray(8);
                return true;
            }
            return false;
        }

        // Method to get ChartData by Id
        public static ChartData GetChartDataById(int id)
        {
            return _chartDataList.FirstOrDefault(cd => cd.Id == id);
        }
    }
}
