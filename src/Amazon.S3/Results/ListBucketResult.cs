﻿using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Amazon.S3
{
    [XmlRoot("ListBucketResult", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/")]
    public class ListBucketResult // : IReadOnlyList<IBlob>
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Marker")]
        public string Marker { get; set; }

        [XmlElement("MaxKeys")]
        public int MaxKeys { get; set; }

        [XmlElement("Prefix")]
        public string Prefix { get; set; }

        [XmlElement("NextContinuationToken")]
        public string NextContinuationToken { get; set; }

        [XmlElement("IsTruncated")]
        public bool IsTruncated { get; set; }

        [XmlElement("Contents")]
        public List<ListBucketObject> Items { get; set; }

        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(ListBucketResult));

        public static ListBucketResult ParseXml(string xmlText)
        {
            var rootEl = XElement.Parse(xmlText); // <ListBucketResult xmlns="http://s3.amazonaws.com/doc/2006-03-01/">

            return (ListBucketResult)serializer.Deserialize(rootEl.CreateReader());
        }

        #region IReadOnlyCollection<IBlob>

        // int IReadOnlyCollection<IBlob>.Count => Items.Count;

        // IBlob IReadOnlyList<IBlob>.this[int index] => Items[index];

        #endregion

        #region IEnumerable<IBlobInfo>

        // IEnumerator<IBlob> IEnumerable<IBlob>.GetEnumerator()
        //     => Items.GetEnumerator();

        // IEnumerator IEnumerable.GetEnumerator()
        //     => Items.GetEnumerator();

        #endregion
    }
}

/*
<?xml version="1.0" encoding="UTF-8"?>
<ListBucketResult xmlns="http://s3.amazonaws.com/doc/2006-03-01/">
	<Name>cmcdn</Name>
	<Prefix>1</Prefix>
	<Marker></Marker>
	<MaxKeys>100</MaxKeys>
	<IsTruncated>true</IsTruncated>
    <NextContinuationToken>1ueGcxLPRx1Tr/XYExHnhbYLgveDs2J/wm36Hy4vbOwM=</NextContinuationToken>
	<Contents>
		<Key>100000/800x600.jpeg</Key>
		<LastModified>2009-06-20T09:54:05.000Z</LastModified>
		<ETag>&quot;c55fad5b272947050bed993ec22c6d0d&quot;</ETag>
		<Size>116879</Size>
		<Owner>
			<ID>9c18bda0312b59b259789b4acf29a06efdb6193a4ef51fcafa739f5cda4f3bf0</ID>
			<DisplayName>jason17095</DisplayName>
		</Owner>
		<StorageClass>STANDARD</StorageClass>
	</Contents>
	<Contents>
		<Key>100001/800x600.jpeg</Key>
		<LastModified>2009-06-20T09:54:01.000Z</LastModified>
		<ETag>&quot;4ef58e19a01ea04d4f9da27c6f6638d7&quot;</ETag>
		<Size>116882</Size>
		<Owner>
			<ID>9c18bda0312b59b259789b4acf29a06efdb6193a4ef51fcafa739f5cda4f3bf0</ID>
			<DisplayName>jason17095</DisplayName>
		</Owner>
		<StorageClass>STANDARD</StorageClass>
	</Contents>
</ListBucketResult>
*/
