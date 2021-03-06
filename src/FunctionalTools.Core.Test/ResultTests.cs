using NUnit.Framework;

namespace FunctionalTools.Core.Test
{
    /// <summary>
    /// Tests for <see cref="Result{T}"/>.
    /// </summary>
    internal static class ResultTests
    {
        //--------------------------------------------------
        [Test]
        public static void Failure_ValidatesBehavior()
        {
            Assert.Multiple(() =>
            {
                // use case: default tag
                {
                    var result = Result<object>.Failure(Error.None);
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.State, Is.EqualTo(ResultState.Failure));
                    Assert.That(result.Tag, Is.EqualTo(string.Empty));
                    Assert.That(result.IsFailure, Is.True);
                    Assert.That(result.IsSuccess, Is.False);
                }

                // use case: custom tag
                {
                    var result = Result<object>.Failure(Error.None, tag: "tag");
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.State, Is.EqualTo(ResultState.Failure));
                    Assert.That(result.Tag, Is.EqualTo("tag"));
                }
            });
        }

        //--------------------------------------------------
        [Test]
        public static void Success_ValidatesBehavior()
        {
            Assert.Multiple(() =>
            {
                // use case: default tag
                {
                    var value = new object();
                    var result = Result<object>.Success(value);
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.State, Is.EqualTo(ResultState.Success));
                    Assert.That(result.Tag, Is.EqualTo(string.Empty));
                    Assert.That(value, Is.EqualTo(result.Unwrap()));
                    Assert.That(result.IsFailure, Is.False);
                    Assert.That(result.IsSuccess, Is.True);
                }

                // use case: custom tag
                {
                    var value = new object();
                    var result = Result<object>.Success(value, tag: "tag");
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.State, Is.EqualTo(ResultState.Success));
                    Assert.That(result.Tag, Is.EqualTo("tag"));
                    Assert.That(value, Is.EqualTo(result.Unwrap()));
                }
            });
        }

        //--------------------------------------------------
        [Test]
        public static void Unwrap_ValidatesBehavior()
        {
            Assert.Multiple(() =>
            {
                // use case: default tag
                {
                    var result = Result<object>.Failure(Error.None);
                    Assert.That(
                        () => result.Unwrap(),
                        Throws.InvalidOperationException.With.Property("Message")
                            .EqualTo(Constants.ErrorMessages.FailureResultUnwrap));
                }

                // use case: custom tag
                {
                    var result = Result<object>.Failure(Error.None, tag: "tag");
                    Assert.That(
                        () => result.Unwrap(),
                        Throws.InvalidOperationException.With.Property("Message")
                            .EqualTo($"{Constants.ErrorMessages.FailureResultUnwrap} Tag: tag"));
                }
            });
        }
    }
}