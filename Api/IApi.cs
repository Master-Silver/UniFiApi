﻿using KoenZomers.UniFi.Api.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoenZomers.UniFi.Api
{
    public interface IApi
    {
        Uri BaseUri { get; }
        int ConnectionTimeout { get; set; }
        bool IsAuthenticated { get; }
        string SiteId { get; }

        Task<bool> Authenticate(string username, string password);
        Task<ResponseEnvelope<Clients>> AuthorizeGuest(string macAddress);
        Task<ResponseEnvelope<Clients>> BlockClient(Clients client);
        Task<ResponseEnvelope<Clients>> BlockClient(string macAddress);
        void DisableSslValidation();
        void EnableTls11and12();
        Task<string> EnsureAuthenticatedGetRequest(Uri uri);
        Task<string> EnsureAuthenticatedPostRequest(Uri uri, string postData);
        Task<List<Clients>> GetActiveClients();
        Task<List<Clients>> GetAllClients();
        Task<List<ClientSession>> GetClientHistory(string macAddress, int limit = 5);
        Task<List<Device>> GetDevices();
        Task<List<Network>> GetNetworks();
        Task<List<Site>> GetSites();
        Task<List<WirelessNetwork>> GetWirelessNetworks();
        Task<bool> Logout();
        Task<bool> Reauthenticate();
        Task<ResponseEnvelope<Clients>> RemoveClients(string[] macArray);
        Task<ResponseEnvelope<Clients>> RenameClient(Clients client, string name);
        Task<ResponseEnvelope<Clients>> RenameClient(string userId, string name);
        Task<ResponseEnvelope<Clients>> UnauthorizeGuest(string macAddress);
        Task<ResponseEnvelope<Clients>> UnblockClient(Clients client);
        Task<ResponseEnvelope<Clients>> UnblockClient(string macAddress);
    }
}