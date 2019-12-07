using System;

namespace Brents6502.Assembling.Repositories
{
    [Serializable]
    public class LabelAddressNotAssignedException : Exception
    {
        public LabelAddressNotAssignedException(string labelName) : base($"The label {labelName} is being accessed but a valid address has not been set")
        {

        }
    }
}