﻿using System;
using System.Collections.Generic;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using pstsdk.layer.pst;
using pstsdk.test.mocks.MockPropBags;

namespace pstsdk.test.mocks.MockDBContexts
{
    public class MockDBContext : IDBAccessor
    {
        public IPropertyObject GetPropertyObjectByNodeId(uint nodeID)
        {
            return new MockPropBag();
        }

        public IPropertyObject GetSubObjectByNodeId(IPropertyObject parentObject, uint nodeID)
        {
            return new MockPropBag();
        }

        public IEnumerable<NodeID> GetNodeIDsByNodeTypeId(NidType nidType)
        {
            var nodeIdList = new List<NodeID>();
            return nodeIdList;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNodeId(IPropertyObject parent, uint childNode)
        {
            var propertyObjectList = new List<IPropertyObject>();
            return propertyObjectList;
        }

        public int GetSubObjectCountByNodeId(IPropertyObject parent, uint childNode)
        {            
            return 1;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNidType(IPropertyObject parent, NidType nidType)
        {
                var propertyObjectList = new List<IPropertyObject>();

                if (nidType == NidType.nid_type_hierarchy_table)
                {
                    propertyObjectList.Add(new Folder(this, new MockPropBag()));
                    propertyObjectList.Add(new Folder(this, new DifferentMockPropBag()));
                }
                else if (nidType == NidType.nid_type_contents_table)
                {
                    propertyObjectList.Add(new Message(this, new DifferentMockPropBag()));
                    propertyObjectList.Add(new Message(this, new DifferentMockPropBag()));
                }

                return propertyObjectList;
        }

        public int GetSubObjectCountByNidType(IPropertyObject parent, NidType nidType)
        {
            return 2;
        }

        public IEnumerable<NodeInfo> Nodes
        {
            get 
            {
                var nodes = new List<NodeInfo>
                                {
                                    new NodeInfo()
                                        {NodeId = new NodeID() {Value = (UInt32) NodeID.Predefined.nid_root_folder}}
                                };

                return nodes; 
            }
        }

        public IEnumerable<BlockInfo> Blocks
        {
            get { return new List<BlockInfo>(); }
        }

        public void Dispose()
        {
            return;
        }
    }
}
