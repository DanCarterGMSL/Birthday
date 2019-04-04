namespace Birthday
{
    using System;
    using NodaTime;

    public class Program
    {
        public static void Main(string[] args)
        {
            var birthTimeZone = DateTimeZoneProviders.Tzdb["Europe/London"];
            var birthDateTime = new LocalDateTime(1992, 04, 04, 00, 12, 00);
            var birthInstant = birthDateTime.InZoneStrictly(birthTimeZone).ToInstant();

            var clock = SystemClock.Instance;

            do
            {
                var now = clock.GetCurrentInstant();

                var duration = Instant.Subtract(now, birthInstant);

                Console.WriteLine($"{duration.Days:N0} days, {duration.Hours:N0} hours, {duration.Minutes:N0} minutes, {duration.Seconds:N0} seconds");
                Console.WriteLine();
                Console.WriteLine($"{duration.TotalDays:N0} total days");
                Console.WriteLine($"{duration.TotalHours:N0} total hours");
                Console.WriteLine($"{duration.TotalMinutes:N0} total minutes");
                Console.WriteLine($"{duration.TotalSeconds:N0} total seconds");
                Console.WriteLine($"{duration.TotalMilliseconds:N0} total milliseconds");

            } while (string.IsNullOrEmpty(Console.ReadLine()));
        }
    }
}
