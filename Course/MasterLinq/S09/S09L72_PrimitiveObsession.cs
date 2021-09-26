using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Course.MasterLinq.S09
{
    public class S09L72_PrimitiveObsession
    {

    }

    public struct Money : IEqualityComparer<Money>, IComparer<Money>
    {
        private const int KopecFactor = 100;
        private readonly decimal _amountInRubles;

        private Money(decimal amountInRub)
        {
            this._amountInRubles = decimal.Round(amountInRub, 2);
        }

        private Money(long amountInKopecs)
        {
            this._amountInRubles = (decimal) amountInKopecs / KopecFactor;
        }

        public static Money FromKopecs(long amountInKopecs)
        {
            return new Money(amountInKopecs);
        }

        public static Money FromRubles(decimal amountInRubles)
        {
            return new Money(amountInRubles);
        }

        public decimal AmountInRubles => this._amountInRubles;
        public decimal AmountInKopecs => (int) (this._amountInRubles * KopecFactor);

        public int CompareTo(Money other)
        {
            if(this._amountInRubles < other._amountInRubles) return -1;
            if(this._amountInRubles == other._amountInRubles) return 0;
            else return 1;
        }


        public int Compare(Money x, Money y)
        {
            throw new System.NotImplementedException();
        }

        public bool Equals(Money x, Money y)
        {
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] Money obj)
        {
            return obj.GetHashCode();
        }

        public Money Add(Money other)
        {
            return new Money(this._amountInRubles + other._amountInRubles);
        }

        public Money Subtract(Money other)
        {
            return new Money(this._amountInRubles - other._amountInRubles);
        }

        public static Money operator +(Money m1, Money m2)
        {
            return m1.Add(m2);
        }

        public static Money operator -(Money m1, Money m2)
        {
            return m1.Subtract(m2);
        }

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return m1.Equals(m2);
        }
    }
}