using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts;
using ThesisProject.Contracts.AttributeValues;
using ThesisProject.Contracts.Instances;

namespace Utility
{
    public class DataGenerator : IDataGenerator
    {
        private readonly int entitiesCount;
        private readonly int linksCount;
        private const int AccountEntityId = 1;


        private const int AccountNumberAttributeId = 1;
        private const int TransactionNumberAttributeId = 2;
        private const int TransactionDateAttributeId = 3;
        private const int TransactionAmountAttributeId = 4;

        private static Random random = new Random();

        public DataGenerator(int entitiesCount, int linksCount)
        {
            this.entitiesCount = entitiesCount;
            this.linksCount = linksCount;
        }

        public List<EntityInstance> EntityInstances { get; private set; }
        public List<LinkInstance> LinkInstances { get; private set; }

        private void Init()
        {
            EntityInstances = new List<EntityInstance>(entitiesCount);
            LinkInstances = new List<LinkInstance>(linksCount);
            accountNumbers = new HashSet<string>();
            transactionNumber = 1;
        }

        public void Generate()
        {
            Init();

            GenerateEntityInstances();
            GenerateLinkInstances();
        }

        private void GenerateEntityInstances()
        {
            for (int i = 0; i < entitiesCount; i++)
            {
                EntityInstances.Add(GenerateEntityInstance());
            }
        }

        private void GenerateLinkInstances()
        {
            for (int i = 0; i < linksCount; i++)
            {
                LinkInstances.Add(GenerateLinkInstance());
            }
        }

        private EntityInstance GenerateEntityInstance()
        {
            return new EntityInstance()
            {
                ElementId = AccountEntityId,
                Id = Guid.NewGuid(),
                AttributeValues = GenerateAccountAttributeValues()
            };
        }
        private LinkInstance GenerateLinkInstance()
        {
            int fromIndex = random.Next() % entitiesCount;
            int toIndex = random.Next() % entitiesCount;

            while(fromIndex == toIndex)
            {
                toIndex = random.Next() % entitiesCount;
            }

            return new LinkInstance()
            {
                ElementId = AccountEntityId,
                Id = Guid.NewGuid(),
                AttributeValues = GenerateTransactionAttributeValues(),
                From = this.EntityInstances[fromIndex].Id,
                To = this.EntityInstances[toIndex].Id
            };
        }

        private HashSet<BaseAttributeValue> GenerateAccountAttributeValues()
        {
            return new HashSet<BaseAttributeValue>()
            {
                GenerateAccountNumberAttributeValue()
            };
        }
        private HashSet<BaseAttributeValue> GenerateTransactionAttributeValues()
        {
            return new HashSet<BaseAttributeValue>()
            {
                GenerateTransactionDateAttributeValue(),
                GenerateTransactionNumberAttributeValue(),
                GenerateTransactionAmountAttributeValue()
            };
        }

        private HashSet<string> accountNumbers = new HashSet<string>();

        private BaseAttributeValue GenerateAccountNumberAttributeValue()
        {
            string accountNumber;

            do
            {
                accountNumber = random.Next().ToString().PadLeft(20, '0');

            } while (accountNumbers.Contains(accountNumber));

            return new StringAttributeValue()
            {
                AttributeId = AccountNumberAttributeId,
                Values = new HashSet<string>() {
                    accountNumber
                }
            };
        }

        private int transactionNumber = 1;

        private BaseAttributeValue GenerateTransactionNumberAttributeValue()
        {
            return new IntAttributeValue()
            {
                AttributeId = TransactionNumberAttributeId,
                Values = new HashSet<int>() {
                    transactionNumber++
                }
            };
        }

        private BaseAttributeValue GenerateTransactionDateAttributeValue()
        {
            return new DateTimeAttributeValue()
            {
                AttributeId = TransactionDateAttributeId,
                Values = new HashSet<DateTime>() {
                    RandomDay()
                }
            };
        }

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days * 24 * 60 * 60;
            return start.AddSeconds(random.Next(range));
        }
        private BaseAttributeValue GenerateTransactionAmountAttributeValue()
        {
            return new IntAttributeValue()
            {
                AttributeId = TransactionAmountAttributeId,
                Values = new HashSet<int>() {
                    random.Next(1000, int.MaxValue)
                }
            };
        }

    }
}
