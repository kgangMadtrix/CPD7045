﻿using System;
using Aps.BillingCompanies;
using Aps.Customer;
using Aps.IntegrationEvents;
using Aps.IntegrationEvents.Serialization;
using Autofac;
using Caliburn.Micro;

namespace Aps.Audit
{
    public class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            // construct the dependency injection builder that when built, will structure and "know"
            // the dependency hierarchy/chains

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<EventIntegrationService>().As<EventIntegrationService>().SingleInstance();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<CustomerRepository>().As<CustomerRepository>().InstancePerDependency();
            builder.RegisterType<BillingCompanyRepository>().As<BillingCompanyRepository>().InstancePerDependency();
            builder.RegisterType<BinaryEventSerializer>().As<BinaryEventSerializer>().InstancePerDependency();
            builder.RegisterType<BinaryEventDeSerializer>().As<BinaryEventDeSerializer>().InstancePerDependency();

            Container = builder.Build();

            Console.ReadLine();
        }
    }
}