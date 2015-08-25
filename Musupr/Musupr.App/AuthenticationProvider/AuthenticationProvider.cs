﻿using Musupr.Domain.Models;
using Musupr.Service;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Musupr.App.MusuprAuthenticationProvider
{
    public class AuthenticationProvider : OAuthAuthorizationServerProvider
    {
        private AccountService _accountService;

        public AuthenticationProvider(AccountService accountService)
        {
            _accountService = accountService;
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var identity = _accountService.FindUser(context);

            if (identity == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            else
            {
                var props = new AuthenticationProperties(new Dictionary<string, string>());

                foreach (var claim in identity.Claims)
                {
                    props.Dictionary.Add(claim.Type, claim.Value);
                }

                var ticket = new AuthenticationTicket(identity, props);

                context.Validated(ticket);
            }
        }

    }
}
