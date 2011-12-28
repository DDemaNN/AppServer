﻿using System;
using System.Linq;
using Castle.Core;
using Castle.Core.Logging;
using Inceptum.AppServer.Configuration;
using Inceptum.AppServer.Monitoring;
using Inceptum.Core.Messaging;
using Inceptum.Core.Utils;

namespace Inceptum.AppServer
{

    internal class HbSender : IDisposable, IStartable
    {
        private const int HB_PERIOD = 10000;
        private readonly IHost m_Host;
        private readonly IMessagingEngine m_Engine;
        private readonly string m_ManagementTransport;
        private readonly string m_HbTopic;
        private PeriodicalBackgroundWorker m_PeriodicalBackgroundWorker;
        private readonly ILogger m_Logger;
        private string m_InstanceName;

        public HbSender(IHost host, IMessagingEngine engine, SonicEndpoint hbEndpoint,ILogger logger, string environment)
        {
            m_Logger = logger;
            m_Engine = engine;
            m_ManagementTransport = hbEndpoint.TransportId;
            m_HbTopic = hbEndpoint.Destination;
            m_Host = host;
            m_InstanceName = string.Format("{0}({1})", Environment.MachineName, environment);
        }


        private void sendHb()
        {
            var hbMessage = new HostHbMessage
                                {
                                    Services = m_Host.HostedApps.Select(a => a.Name).ToArray(),
                                    InstanceName = m_InstanceName,
                                    Period = HB_PERIOD
                                };
            try
            {
                m_Engine.Send(hbMessage, m_HbTopic, m_ManagementTransport);
            }catch(Exception e)
            {
                m_Logger.WarnFormat(e,"Failed to send hb");
            }
        }


        public void Start()
        {
            m_PeriodicalBackgroundWorker = new PeriodicalBackgroundWorker("Server HB sender", HB_PERIOD, sendHb);
        }

        public void Stop()
        {
           
        }

        public void Dispose()
        {
            m_PeriodicalBackgroundWorker.Dispose();
        }
    }
}