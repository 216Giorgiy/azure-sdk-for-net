// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Media.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class to specify properties of all content keys in Streaming Policy
    /// </summary>
    public partial class StreamingPolicyContentKeys
    {
        /// <summary>
        /// Initializes a new instance of the StreamingPolicyContentKeys class.
        /// </summary>
        public StreamingPolicyContentKeys()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StreamingPolicyContentKeys class.
        /// </summary>
        /// <param name="defaultKey">Default content key for an encryption
        /// scheme</param>
        /// <param name="keyToTrackMappings">Representing tracks needs
        /// sepearete content key</param>
        public StreamingPolicyContentKeys(DefaultKey defaultKey = default(DefaultKey), IList<StreamingPolicyContentKey> keyToTrackMappings = default(IList<StreamingPolicyContentKey>))
        {
            DefaultKey = defaultKey;
            KeyToTrackMappings = keyToTrackMappings;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets default content key for an encryption scheme
        /// </summary>
        [JsonProperty(PropertyName = "defaultKey")]
        public DefaultKey DefaultKey { get; set; }

        /// <summary>
        /// Gets or sets representing tracks needs sepearete content key
        /// </summary>
        [JsonProperty(PropertyName = "keyToTrackMappings")]
        public IList<StreamingPolicyContentKey> KeyToTrackMappings { get; set; }

    }
}