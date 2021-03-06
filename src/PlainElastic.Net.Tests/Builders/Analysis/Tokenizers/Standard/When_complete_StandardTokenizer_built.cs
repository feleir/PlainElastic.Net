﻿using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StandardTokenizer))]
    class When_complete_StandardTokenizer_built
    {
        Because of = () => result = new StandardTokenizer()
                                            .Name("name")
                                            .Version("3.6")
                                            .MaxTokenLength(100500)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'standard'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_max_token_length_part = () => result.ShouldContain("'max_token_length': 100500".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'standard'," +
                                                                    "'version': '3.6'," +
                                                                    "'max_token_length': 100500," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}