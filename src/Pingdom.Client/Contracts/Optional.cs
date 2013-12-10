﻿namespace Pingdom.Client.Contracts
{
    using System.Linq;

    public class ActionArgs
    {
        /// <summary>
        /// Only include actions generated later than this timestamp. Format is UNIX time.
        /// </summary>
        public long? From { get; set; }

        /// <summary>
        /// Only include actions generated prior to this timestamp. Format is UNIX time.
        /// </summary>
        public long? To { get; set; }

        /// <summary>
        /// Limits the number of returned results to the specified quantity.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Offset for listing.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Comma-separated list of check identifiers. Limit results to actions generated from these checks.
        /// </summary>
        public string CheckIds { get; set; }

        /// <summary>
        /// Comma-separated list of contact identifiers. Limit results to actions sent to these contacts.
        /// </summary>
        public string ContactIds { get; set; }

        /// <summary>
        /// Comma-separated list of statuses. Limit results to actions with these statuses.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Comma-separated list of via mediums. Limit results to actions with these mediums.
        /// </summary>
        public string Via { get; set; }
    }

    public static class QueryStringExtensions
    {
        public static string ToQueryString(this object source)
        {
            var properties = source.GetType()
                                   .GetProperties()
                                   .ToDictionary(k => k.Name, v => v.GetValue(source));

            var queryString = properties.Where(p => p.Value != null)
                                        .Select(p => string.Format("{0}={1}", p.Key.ToLower(), p.Value.ToString()));

            return string.Format("?{0}", string.Join("&", queryString));
        }
    }

}
