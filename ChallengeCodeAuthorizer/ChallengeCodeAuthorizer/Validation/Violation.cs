﻿namespace ChallengeCodeAuthorizer.Validation
{
   
    public class Violation
    {
        #region Public Methods
        public string Value { get; private set; }
        #endregion

        #region Public properties
        public static Violation AccountAlreadyInitialized { get { return new Violation("account-already-initialized"); } }
        public static Violation AccountNotInitialized { get { return new Violation("account-not-initialized"); } }
        public static Violation CardNotActive { get { return new Violation("card-not-active"); } }
        public static Violation InsufficientLimit { get { return new Violation("insufficient-limit"); } }
        public static Violation HighFrequencySmallInterval { get { return new Violation("highfrequency-small-interval"); } }
        public static Violation DoubleTransaction { get { return new Violation("double-transaction"); } }
        #endregion

        #region Private Properties
        private Violation(string value) { Value = value; }
        #endregion
    }
}
