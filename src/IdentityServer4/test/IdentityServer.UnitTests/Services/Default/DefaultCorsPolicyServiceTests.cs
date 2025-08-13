// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Threading.Tasks;
using FluentAssertions;
using IdentityServer.UnitTests.Common;
using IdentityServer4.Services;
using Xunit;

namespace IdentityServer.UnitTests.Services.Default
{
    public class DefaultCorsPolicyServiceTests
    {
        private const string Category = "DefaultCorsPolicyService";

        private DefaultCorsPolicyService subject;

        public DefaultCorsPolicyServiceTests()
        {
            subject = new DefaultCorsPolicyService(TestLogger.Create<DefaultCorsPolicyService>());
        }

        [Fact]
        [Trait("Category", Category)]
        public async Task IsOriginAllowed_null_param_ReturnsFalse()
        {
            var check1 = await subject.IsOriginAllowedAsync(null);
            Assert.False(check1);
            var check2 = await subject.IsOriginAllowedAsync(String.Empty);
            Assert.False(check2);
            var check3 = await subject.IsOriginAllowedAsync("    ");
            Assert.False(check3);
        }

        [Fact]
        [Trait("Category", Category)]
        public async Task IsOriginAllowed_OriginIsAllowed_ReturnsTrue()
        {
            subject.AllowedOrigins.Add("http://foo");
            var value = await subject.IsOriginAllowedAsync("http://foo");
            Assert.True(value);
        }

        [Fact]
        [Trait("Category", Category)]
        public async Task IsOriginAllowed_OriginIsNotAllowed_ReturnsFalse()
        {
            subject.AllowedOrigins.Add("http://foo");
            var ret = await subject.IsOriginAllowedAsync("http://bar");
            Assert.False(ret);
        }

        [Fact]
        [Trait("Category", Category)]
        public async Task IsOriginAllowed_OriginIsInAllowedList_ReturnsTrue()
        {
            subject.AllowedOrigins.Add("http://foo");
            subject.AllowedOrigins.Add("http://bar");
            subject.AllowedOrigins.Add("http://baz");
            var ret = await subject.IsOriginAllowedAsync("http://bar");
            Assert.True(ret);
        }

        [Fact]
        [Trait("Category", Category)]
        public async Task IsOriginAllowed_OriginIsNotInAllowedList_ReturnsFalse()
        {
            subject.AllowedOrigins.Add("http://foo");
            subject.AllowedOrigins.Add("http://bar");
            subject.AllowedOrigins.Add("http://baz");
            var ret = await subject.IsOriginAllowedAsync("http://quux");
            Assert.False(ret);
        }

        [Fact]
        [Trait("Category", Category)]
        public async Task IsOriginAllowed_AllowAllTrue_ReturnsTrue()
        {
            subject.AllowAll = true;
            var ret = await subject.IsOriginAllowedAsync("http://foo");
            Assert.True(ret);
        }
    }
}
