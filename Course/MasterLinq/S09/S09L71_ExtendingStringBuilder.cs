using System;
using System.Collections.Generic;
using System.Text;
using Course.MasterLinq.S09;

namespace Course.MasterLinq
{
    public class S09L71_ExtendingStringBuilder
    {

    }

    public class TravelInfo
    {
        public string Name { get; set; }
        public string CardInfo { get; set; }
        public string Reason { get; set; }
    }

    public class TravelInfoViewModel
    {
        public TravelInfo TravelInfo { get; }
        private List<string> terminalInfo;

        public void Finish()
        {
            string report = ReportFactory.CreateFinalReport(terminalInfo, TravelInfo);
            Console.WriteLine(report);
        }
    }

    public class ReportFactory
    {
        public static string CreateFinalReport(List<string> terminalInfo, TravelInfo info)
        {

            #region Imperative code
            /*
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"Name = {info.Name}");
            sb.AppendLine();

            if (Validate(info.CardInfo))
            {
                sb.AppendFormat($"Card {info.CardInfo} is validated.");
                sb.AppendLine();
            }
            else
            {
                sb.AppendFormat("Card validation failed.");
                sb.AppendLine();
            }

            sb.AppendLine(string.Format($"Reason is {info.Reason}"));

            sb.AppendFormat($"Reason is {info.Reason}");
            sb.AppendLine();

            foreach (var cur in terminalInfo)
            {
                sb.AppendFormat($"Terminal info record = {cur}");
                sb.AppendLine();
            }
            */
            #endregion

            #region With the extension method AppendFormattedLine()
            // Refactored code
            // With all due respect, but it looks really (uber) ugly to me!!
            return new StringBuilder()
                            .AppendFormattedLine($"Name = {info.Name}")
                            .When(() => Validate(info.CardInfo),
                                failure: builder => builder.AppendFormattedLine("Card validation failed."),
                                success: builder => builder.AppendFormattedLine($"Card {info.CardInfo} is validated."))
                            .AppendFormattedLine($"Reason is {info.Reason}")
                            .AppendSequence(terminalInfo,
                                (builder, current)
                                    => builder.AppendFormattedLine($"Terminal info record = {current}"))
                            .ToString();
            /*
            if (Validate(info.CardInfo))
            {
                sb.AppendFormattedLine($"Card {info.CardInfo} is validated.");
            }
            else
            {
                sb.AppendFormattedLine("Card validation failed.");
            }


            sb.AppendFormattedLine($"Reason is {info.Reason}");


            foreach (var cur in terminalInfo)
            {
                sb.AppendFormattedLine($"Terminal info record = {cur}");
            }
            return sb.ToString();
            */
            #endregion

        }

        private static bool Validate(string infoCardInfo)
        {
            return new Random().Next(0, 1) == 1;
        }
    }
}