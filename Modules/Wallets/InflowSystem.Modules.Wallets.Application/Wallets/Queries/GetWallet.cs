﻿using InflowSystem.Modules.Wallets.Application.Wallets.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Queries
{
    internal class GetWallet : IQuery<WalletDetailsDto>
    {
        public Guid WalletId { get; set; }
    }
}
