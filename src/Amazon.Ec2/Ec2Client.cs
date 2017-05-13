﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amazon.Ec2
{
    public class Ec2Client : AwsClient
    {
        public static readonly string Version = "2016-11-15";
        public const string Namespace = "http://ec2.amazonaws.com/doc/2016-11-15/";

        public Ec2Client(AwsRegion region, IAwsCredential credential)
            : base(AwsService.Ec2, region, credential)
        { }

        #region Shortcuts

        public async Task<Image> DescribeImageAsync(string id)
        {
            var result = await DescribeImagesAsync(new DescribeImagesRequest { ImageIds = { id } });

            return result.Images.Length > 0 ? result.Images[0] : null;
        }

        public async Task<Subnet> DescribeSubnetAsync(string id)
        {
            var result = await DescribeSubnetsAsync(new DescribeSubnetsRequest { SubnetIds = { id } });

            return result.Subnets.Count > 0 ? result.Subnets[0] : null;
        }

        public async Task<NetworkInterface> DescribeNetworkInterfaceAsync(string id)
        {
            var result = await DescribeNetworkInterfacesAsync(new DescribeNetworkInterfacesRequest { NetworkInterfaceIds = { id } });

            return result.NetworkInterfaces.Length > 0 ? result.NetworkInterfaces[0] : null;
        }

        public async Task<Instance> DescribeInstanceAsync(string instanceId)
        {
            var result = await DescribeInstancesAsync(new DescribeInstancesRequest { InstanceIds = { instanceId } });

            return result.Instances.Count > 0 ? result.Instances[0] : null;
        }

        public async Task<Volume> DescribeVolumeAsync(string volumeId)
        {
            var result = await DescribeVolumesAsync(new DescribeVolumesRequest { VolumeIds = { volumeId } });

            return result.Volumes.Length > 0 ? result.Volumes[0] : null;
        }

        public async Task<Vpc> DescribeVpcAsync(string vpcId)
        {
            var result = await DescribeVpcsAsync(new DescribeVpcsRequest { VpcIds = { vpcId } });

            return result.Vpcs.Length > 0 ? result.Vpcs[0] : null;
        }

        #endregion

        #region Instances

        public async Task<DescribeInstancesResponse> DescribeInstancesAsync(DescribeInstancesRequest request)
        {
            var responseText = await SendAsync(request).ConfigureAwait(false);

            return DescribeInstancesResponse.Parse(responseText);
        }

        public Task<RunInstancesResponse> RunInstancesAsync(RunInstancesRequest request)
        {
            return SendAsync<RunInstancesResponse>(request);
        }

        public Task<TerminateInstancesResponse> TerminateInstancesAsync(TerminateInstancesRequest request)
        {
            return SendAsync<TerminateInstancesResponse>(request);

        }

        #endregion

        #region Images

        public Task<DescribeImagesResponse> DescribeImagesAsync(DescribeImagesRequest request)
        {
            return SendAsync<DescribeImagesResponse>(request);
        }

        #endregion

        #region Network Interfaces

        public Task<DescribeNetworkInterfacesResponse> DescribeNetworkInterfacesAsync(DescribeNetworkInterfacesRequest request)
        {
            return SendAsync<DescribeNetworkInterfacesResponse>(request);
        }

        #endregion

        #region Subnets

        public Task<DescribeSubnetsResponse> DescribeSubnetsAsync(DescribeSubnetsRequest request)
        {
            return SendAsync<DescribeSubnetsResponse>(request);
        }

        #endregion

        #region Vps

        public Task<DescribeVpcsResponse> DescribeVpcsAsync(DescribeVpcsRequest request)
        {
            return SendAsync<DescribeVpcsResponse>(request);
        }

        #endregion

        #region Volumes

        public Task<DescribeVolumesResponse> DescribeVolumesAsync(DescribeVolumesRequest request)
        {
            return SendAsync<DescribeVolumesResponse>(request);
        }

        #endregion

        #region API Helpers

        private async Task<string> SendAsync(IEc2Request request)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, Endpoint)
            {
                Content = GetPostContent(request.ToParams())
            };

            return await SendAsync(httpRequest).ConfigureAwait(false);
        }

        private async Task<TResponse> SendAsync<TResponse>(IEc2Request request)
            where TResponse: IEc2Response
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, Endpoint)
            {
                Content = GetPostContent(request.ToParams())
            };

            var responseXml = await SendAsync(httpRequest).ConfigureAwait(false);

            return Ec2ResponseHelper<TResponse>.ParseXml(responseXml);
        }

        private FormUrlEncodedContent GetPostContent(Dictionary<string, string> parameters)
        {
            parameters.Add("Version", Version);

            return new FormUrlEncodedContent(parameters);
        }

        protected override async Task<Exception> GetExceptionAsync(HttpResponseMessage response)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            throw new Exception(response.StatusCode + "/" + responseText);
        }

        #endregion
    }
}

// http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Welcome.html

/*
AcceptReservedInstancesExchangeQuote
AcceptVpcPeeringConnection
AllocateAddress
AllocateHosts
AssignIpv6Addresses
AssignPrivateIpAddresses
AssociateAddress
AssociateDhcpOptions
AssociateIamInstanceProfile
AssociateRouteTable
AssociateSubnetCidrBlock
AssociateVpcCidrBlock
AttachClassicLinkVpc
AttachInternetGateway
AttachNetworkInterface
AttachVolume
AttachVpnGateway
AuthorizeSecurityGroupEgress
AuthorizeSecurityGroupIngress
BundleInstance
CancelBundleTask
CancelConversionTask
CancelExportTask
CancelImportTask
CancelReservedInstancesListing
CancelSpotFleetRequests
CancelSpotInstanceRequests
ConfirmProductInstance
CopyImage
CopySnapshot
CreateCustomerGateway
CreateDhcpOptions
CreateEgressOnlyInternetGateway
CreateFlowLogs
CreateImage
CreateInstanceExportTask
CreateInternetGateway
CreateKeyPair
CreateNatGateway
CreateNetworkAcl
CreateNetworkAclEntry
CreateNetworkInterface
CreatePlacementGroup
CreateReservedInstancesListing
CreateRoute
CreateRouteTable
CreateSecurityGroup
CreateSnapshot
CreateSpotDatafeedSubscription
CreateSubnet
CreateTags
CreateVolume
CreateVpc
CreateVpcEndpoint
CreateVpcPeeringConnection
CreateVpnConnection
CreateVpnConnectionRoute
CreateVpnGateway
DeleteCustomerGateway
DeleteDhcpOptions
DeleteEgressOnlyInternetGateway
DeleteFlowLogs
DeleteInternetGateway
DeleteKeyPair
DeleteNatGateway
DeleteNetworkAcl
DeleteNetworkAclEntry
DeleteNetworkInterface
DeletePlacementGroup
DeleteRoute
DeleteRouteTable
DeleteSecurityGroup
DeleteSnapshot
DeleteSpotDatafeedSubscription
DeleteSubnet
DeleteTags
DeleteVolume
DeleteVpc
DeleteVpcEndpoints
DeleteVpcPeeringConnection
DeleteVpnConnection
DeleteVpnConnectionRoute
DeleteVpnGateway
DeregisterImage
DescribeAccountAttributes
DescribeAddresses
DescribeAvailabilityZones
DescribeBundleTasks
DescribeClassicLinkInstances
DescribeConversionTasks
DescribeCustomerGateways
DescribeDhcpOptions
DescribeEgressOnlyInternetGateways
DescribeExportTasks
DescribeFlowLogs
DescribeHostReservationOfferings
DescribeHostReservations
DescribeHosts
DescribeIamInstanceProfileAssociations
DescribeIdentityIdFormat
DescribeIdFormat
DescribeImageAttribute
DescribeImages
DescribeImportImageTasks
DescribeImportSnapshotTasks
DescribeInstanceAttribute
DescribeInstances
DescribeInstanceStatus
DescribeInternetGateways
DescribeKeyPairs
DescribeMovingAddresses
DescribeNatGateways
DescribeNetworkAcls
DescribeNetworkInterfaceAttribute
DescribeNetworkInterfaces
DescribePlacementGroups
DescribePrefixLists
DescribeRegions
DescribeReservedInstances
DescribeReservedInstancesListings
DescribeReservedInstancesModifications
DescribeReservedInstancesOfferings
DescribeRouteTables
DescribeScheduledInstanceAvailability
DescribeScheduledInstances
DescribeSecurityGroupReferences
DescribeSecurityGroups
DescribeSnapshotAttribute
DescribeSnapshots
DescribeSpotDatafeedSubscription
DescribeSpotFleetInstances
DescribeSpotFleetRequestHistory
DescribeSpotFleetRequests
DescribeSpotInstanceRequests
DescribeSpotPriceHistory
DescribeStaleSecurityGroups
DescribeSubnets
DescribeTags
DescribeVolumeAttribute
DescribeVolumes
DescribeVolumesModifications
DescribeVolumeStatus
DescribeVpcAttribute
DescribeVpcClassicLink
DescribeVpcClassicLinkDnsSupport
DescribeVpcEndpoints
DescribeVpcEndpointServices
DescribeVpcPeeringConnections
DescribeVpcs
DescribeVpnConnections
DescribeVpnGateways
DetachClassicLinkVpc
DetachInternetGateway
DetachNetworkInterface
DetachVolume
DetachVpnGateway
DisableVgwRoutePropagation
DisableVpcClassicLink
DisableVpcClassicLinkDnsSupport
DisassociateAddress
DisassociateIamInstanceProfile
DisassociateRouteTable
DisassociateSubnetCidrBlock
DisassociateVpcCidrBlock
EnableVgwRoutePropagation
EnableVolumeIO
EnableVpcClassicLink
EnableVpcClassicLinkDnsSupport
GetConsoleOutput
GetConsoleScreenshot
GetHostReservationPurchasePreview
GetPasswordData
GetReservedInstancesExchangeQuote
ImportImage
ImportInstance
ImportKeyPair
ImportSnapshot
ImportVolume
ModifyHosts
ModifyIdentityIdFormat
ModifyIdFormat
ModifyImageAttribute
ModifyInstanceAttribute
ModifyInstancePlacement
ModifyNetworkInterfaceAttribute
ModifyReservedInstances
ModifySnapshotAttribute
ModifySpotFleetRequest
ModifySubnetAttribute
ModifyVolume
ModifyVolumeAttribute
ModifyVpcAttribute
ModifyVpcEndpoint
ModifyVpcPeeringConnectionOptions
MonitorInstances
MoveAddressToVpc
PurchaseHostReservation
PurchaseReservedInstancesOffering
PurchaseScheduledInstances
RebootInstances
RegisterImage
RejectVpcPeeringConnection
ReleaseAddress
ReleaseHosts
ReplaceIamInstanceProfileAssociation
ReplaceNetworkAclAssociation
ReplaceNetworkAclEntry
ReplaceRoute
ReplaceRouteTableAssociation
ReportInstanceStatus
RequestSpotFleet
RequestSpotInstances
ResetImageAttribute
ResetInstanceAttribute
ResetNetworkInterfaceAttribute
ResetSnapshotAttribute
RestoreAddressToClassic
RevokeSecurityGroupEgress
RevokeSecurityGroupIngress
RunInstances
RunScheduledInstances
StartInstances
StopInstances
TerminateInstances
UnassignIpv6Addresses
UnassignPrivateIpAddresses
UnmonitorInstances
*/
