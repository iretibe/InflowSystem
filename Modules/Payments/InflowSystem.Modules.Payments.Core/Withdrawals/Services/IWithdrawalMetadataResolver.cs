﻿namespace InflowSystem.Modules.Payments.Core.Withdrawals.Services
{
    internal interface IWithdrawalMetadataResolver
    {
        Guid? TryResolveWithdrawalId(string metadata);
    }
}
