﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Domain.Common.Models
{
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId> 
        where TId : AggregateRootId<TIdType>
    {
        public new AggregateRootId<TIdType> Id { get; protected set; }

        protected AggregateRoot(TId id) : base(id) { }

        protected AggregateRoot() { }
    }
}
