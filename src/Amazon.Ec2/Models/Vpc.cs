﻿using System.Xml.Serialization;

namespace Amazon.Ec2
{
    public class Vpc
    {
        [XmlElement("vpcId")]
        public string VpcId { get; set; }

        [XmlElement("cidrBlock")]
        public string CidrBlock { get; set; }

        [XmlArray("ipv6CidrBlockAssociationSet")]
        [XmlArrayItem("item")]
        public Ipv6CidrBlockAssociation[] Ipv6CidrBlockAssociations { get; set; }

        // default | dedicated | host
        [XmlElement("instanceTenancy")]
        public string InstanceTenancy { get; set; }

        [XmlElement("isDefault")]
        public bool IsDefault { get; set; }

        [XmlElement("dhcpOptionsId")]
        public string DhcpOptionsId { get; set; }

        // pending | available
        [XmlElement("state")]
        public string State { get; set; }
    }

    /*
    // We can't use these yet -- since XML deserialization is case sensitive

    public enum VpcState
    {
        Pending = 1,
        Available = 2
    }

    public enum InstanceTenancy
    {
        Default = 1,
        Dedicated = 2,
        Host = 3
    }
    */
}

/*
<item>
    <vpcId>vpc-1a2b3c4d</vpcId>
    <state>available</state>
    <cidrBlock>10.0.0.0/23</cidrBlock>
    <ipv6CidrBlockAssociationSet>
    <item>
        <ipv6CidrBlock>2001:db8:1234:1a00::/56</ipv6CidrBlock>
        <associationId>vpc-cidr-assoc-abababab</associationId>
        <ipv6CidrBlockState>
            <state>ASSOCIATED</state>
        </ipv6CidrBlockState>
    </item>
    </ipv6CidrBlockAssociationSet>    
    <dhcpOptionsId>dopt-7a8b9c2d</dhcpOptionsId> 
    <instanceTenancy>default</instanceTenancy>
    <isDefault>false</isDefault>
    <tagSet/>
</item>
*/