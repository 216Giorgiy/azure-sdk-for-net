// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using CdnProfile.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using Models;

    /// <summary>
    /// Entry point for CDN profile management API.
    /// </summary>
    public interface ICdnProfiles  :
        ISupportsCreating<CdnProfile.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        ISupportsGettingById<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        ISupportsBatchDeletion,
        IHasManager<ICdnManager>,
        IHasInner<IProfilesOperations>
    {
        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult CheckEndpointNameAvailability(string name);

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Task<CheckNameAvailabilityResult> CheckEndpointNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all of the available CDN REST API operations.
        /// </summary>
        /// <return>List of available CDN REST operations.</return>
        IEnumerable<Microsoft.Azure.Management.Cdn.Fluent.Operation> ListOperations();

        /// <summary>
        /// Check the quota and actual usage of the CDN profiles under the current subscription.
        /// </summary>
        /// <returns>quotas and actual usages of the CDN profiles under the current subscription.</returns>
        IEnumerable<ResourceUsage> ListResourceUsage();

        /// <summary>
        /// Lists all the edge nodes of a CDN service.
        /// </summary>
        /// <returns>list of all the edge nodes of a CDN service.</returns>
        IEnumerable<EdgeNode> ListEdgeNodes();

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal.
        /// Supplemental portal is used to configure advanced feature capabilities that are not
        /// yet available in the Azure portal, such as core reports in a standard profile;
        /// rules engine, advanced HTTP reports, and real-time stats and alerts in a premium profile.
        /// The SSO URI changes approximately every 10 minutes.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <return>The Sso Uri string if successful.</return>
        string GenerateSsoUri(string resourceGroupName, string profileName);

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal.
        /// Supplemental portal is used to configure advanced feature capabilities that are not
        /// yet available in the Azure portal, such as core reports in a standard profile;
        /// rules engine, advanced HTTP reports, and real-time stats and alerts in a premium profile.
        /// The SSO URI changes approximately every 10 minutes.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <return>The Sso Uri string if successful.</return>
        Task<string> GenerateSsoUriAsync(string resourceGroupName, string profileName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content. Available for Verizon profiles.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void LoadEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths);

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content. Available for Verizon profiles.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        Task LoadEndpointContentAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths, 
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts an existing stopped CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StartEndpoint(string resourceGroupName, string profileName, string endpointName);

        /// <summary>
        /// Starts an existing stopped CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        Task StartEndpointAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Forcibly purges CDN endpoint content.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void PurgeEndpointContent(
            string resourceGroupName,
            string profileName,
            string endpointName,
            IList<string> contentPaths);

        /// <summary>
        /// Forcibly purges CDN endpoint content.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        Task PurgeEndpointContentAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths, 
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops an existing running CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StopEndpoint(string resourceGroupName, string profileName, string endpointName);

        /// <summary>
        /// Stops an existing running CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        Task StopEndpointAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            CancellationToken cancellationToken = default(CancellationToken));
    }
}