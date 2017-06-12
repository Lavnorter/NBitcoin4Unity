﻿using System;

namespace QBitNinja4Unity.Models
{
	[Serializable]
	public class GetBlockResponse
	{
		public BlockInformation			additionalInformation;
		public string					extendedInformation;
		public string					block;

		public QBitNinja.Models.GetBlockResponse Result()
		{
			var result = new QBitNinja.Models.GetBlockResponse();
			result.AdditionalInformation	= BlockInformation.Create(additionalInformation);
			result.ExtendedInformation		= extendedInformation.Length==0?null:ExtendedBlockInformation.Create(UnityEngine.JsonUtility.FromJson<ExtendedBlockInformation>(extendedInformation));
			result.Block					= block.Length==0?null:new NBitcoin.Block(NBitcoin.DataEncoders.Encoders.Hex.DecodeData(block));
			return result;
		}
	}
}