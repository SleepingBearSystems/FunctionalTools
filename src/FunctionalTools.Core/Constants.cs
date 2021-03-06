﻿using JetBrains.Annotations;

namespace FunctionalTools.Core
{
    public static class Constants
    {
        public static class ErrorMessages
        {
            [NotNull] public const string FailureResultUnwrap = "State is failure.";

            [NotNull] public const string MaybeHasNoValue = "Has no value.";

            [NotNull] public const string InvalidResultState = "Invalid result state.";
        }
    }
}