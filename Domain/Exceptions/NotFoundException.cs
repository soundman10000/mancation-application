// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.Mancation.Domain

using System;
using MongoDB.Bson;

namespace Mancation.Domain
{
    public class NotFoundException : ArgumentException
    {
        public NotFoundException(string dataName, ObjectId id)
            :base($"Valuetype: {dataName} for id: {id} not found.")
        {
        }
    }
}
