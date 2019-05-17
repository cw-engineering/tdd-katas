#pragma warning disable CS0618 // Used in unit tests only

using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Shouldly;


namespace tdd.exceptions.tests
{
    public static class ShouldlyExtensions
    {
        public static void ShouldBeValidJson(this string json, JsonSchema schema)
        {
            if (!JObject.Parse(json).IsValid(schema, out var errorMessages))
            {
                throw new ShouldAssertException(
                    "json" + Environment.NewLine +
                    "  should be valid but was found invalid" + Environment.NewLine +
                    "Validation Errors" + Environment.NewLine +
                    "  " + string.Join(Environment.NewLine + "  ", errorMessages) + Environment.NewLine +
                    "Actual Json" + Environment.NewLine + json
                );
            }
        }
    }
}
