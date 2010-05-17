#region Using Directives and Copyright Notice

// Copyright (c) 2007-2010, Computer Consultancy Pty Ltd
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the Computer Consultancy Pty Ltd nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL COMPUTER CONSULTANCY PTY LTD BE LIABLE 
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER 
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT 
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY 
// OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH
// DAMAGE.

using System;
using System.Collections.Generic;
using System.Text;

using SD.LLBLGen.Pro.ORMSupportClasses;

#endregion

namespace Interlace.Utilities
{
    public class EntitySchemaProvider
    {
        private static void PrintEntityFields(IEntity2 entity, int indentLevel)
        {
            string indent = "".PadLeft(indentLevel);

            foreach (IEntityField2 field in entity.Fields)
            {
                if (!field.IsPrimaryKey && !field.IsForeignKey)
                {
                    string entityName = field.ContainingObjectName;
                    string fieldName = field.Name;

                    System.Console.Out.WriteLine(indent + entityName + "." + fieldName);
                }
            }
        }

        public static void PrintSchema(IEntityFactory2 factory)
        {
            PrintSchema(factory.Create(), null);
        }

        public static void PrintSchema(IEntityFactory2 factory, IPrefetchPath2 prefetchPath)
        {
            PrintSchema(factory.Create(), prefetchPath);
        }

        public static void PrintSchema(IEntity2 entity)
        {
            PrintSchema(entity, null);
        }

        public static void PrintSchema(IEntity2 entity, IPrefetchPath2 prefetchPath)
        {
            if (prefetchPath != null)
            {
                PrintSchema(prefetchPath, entity.GetEntityFactory().ForEntityName);
            }
            else
            {
                PrintEntityFields(entity, 0);
            }
        }

        private static void PrintSchema(IPrefetchPathElement2 pathElement, string rootEntityName)
        {
            if (pathElement != null)
            {
                string indentation = "".PadLeft(pathElement.GraphLevel);
                string basePropertyName = pathElement.PropertyName;

                IEntityFactory2 relatedEntityFactory = pathElement.EntityFactoryToUse;

                // This is what LLBL does internally.
                if (relatedEntityFactory == null)
                {
                    relatedEntityFactory = pathElement.RetrievalCollection.EntityFactoryToUse;
                }

                string relatedEntityName = relatedEntityFactory.ForEntityName;

                System.Console.Out.WriteLine(indentation + rootEntityName + "." + basePropertyName + " -> " + relatedEntityName);

                if (pathElement.SubPath != null)
                {
                    PrintEntityFields(relatedEntityFactory.Create(), pathElement.GraphLevel + 1);
                    PrintSchema(pathElement.SubPath, relatedEntityFactory.ForEntityName);
                }
            }
        }

        private static void PrintSchema(IPrefetchPath2 path, string rootEntityName)
        {
            for (int i = 0; i < path.Count; i++)
            {
                PrintSchema(path[i], rootEntityName);
            }
        }
    }
}
