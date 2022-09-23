# MyMetapets

## _Introducing the Ability to Raise and Breed Fish in the Metaverse!_

[![MyMetapets](https://bafybeicezpjgptfzc54enl44vk532uuajtyn5nm6ipaumprexxytn2255y.ipfs.nftstorage.link/0000000000000000000000000000000000000000000000000000000000000001.png)](https://mymetapets.app)

> Enjoy the best parts about having your own aquarium!

## Overview

Fish are the first `Pets` that we intend to bring to the Metaverse. Our approach is to deliver a rich and rewarding virtual pet experience starting with the aquarium ecosystem. You can start raising and breeding your own Clownish in a beautiful virtual aquarium now!

- MyMetapets is a Project Dedicated to Web 3 Values
- ✨ Own, Raise, Breed, and Sell Virtual Fish Now ✨

## Current Features

- Use any popular web browser to enjoy and interact with your aquarium
- Buy and sell fish on popular NFT platforms like OpenSea
- Rest assured that your fish are perpetual with Filecoin storage
- Your immutable assets are settled on Ethereum through Polygon
- Discoverable and decentralized through the Valist distribution platform 

## Upcoming Features

- Breed fish to create new NFT's with size and color variations
- Mint your own rare fish to NFT.Storage and sell them on OpenSea
- Curate the perfect aquarium ecosystem and share it online
- More fish species and aquarium customization options to come
- Get premium access and new expansions through the Valist platform 
- Rest assured that all random outcomes are secured through Chainlink

## Long Term Features

- Showcase your virtual aquarium on any smart device or televisions
- Introduce AI to allow your fish to develop based on your care
- Interoperability on popular Metaverse platforms where possible
- Innovative real-world integrations like a holographic fish tank

## Key Technology

| TECH | LINK | DESCRIPTION |
| ------ | ------ | ------ |
| Moralis | [Moralis.io](https://moralis.io) | Decentralized hosting and discovery platform |
| Filecoin | [Filecoin.io](https://filecoin.io) | Decentralized interplanetary storage network |
| NFT.Storage | [NFT.Storage](https://nft.storage) | Perpetual Filecoin storage for public goods |
| Polygon | [Polygon.Technology](https://polygon.technology) | High-speed low-fee "Layer 2" blockchain |
| Chainlink | [Chain.Link](https://chain.link) | Secure offchain oracles and services |
| Valist | [Valist.io](https://valist.io) | Decentralized hosting and discovery platform |
| Unity | [Unity3D.com](https://unity3d.com) | 3D Game engine with rich community extensions |

## Technology Highlights

The following sections highlight some of the code snippets related to `Key Technologies`

### Moralis

The user is authenticated through the Moralis SDK in th UI COntroller https://github.com/biznach/mymetapets/blob/main/Assets/Bizfish/Scripts/BizUIController.cs

Relevant information based on the connected wallet are then displayed and system variables like number of fish owned is captured in the Congratulations Controller https://github.com/biznach/mymetapets/blob/main/Assets/Bizfish/Scripts/BizCongratulationsController.cs

### Filecoin and NFT.Storage

The NFT metadata is stored at ipfs://bafybeieks3k2ql4ehkn3dzoa3q23xe6yi64yo3zpdix3oayifzyjr3d2fe
The NFT image is stored at ipfs://bafybeicezpjgptfzc54enl44vk532uuajtyn5nm6ipaumprexxytn2255y
The NFT model and animation data is stored at ipfs://bafybeiektpbyn5g4f2ep3zwfhp27cokwioqc5jgof2uz7jbs2bq6jjpg4q
There is currently a POC of loading a fish directly from the IPFS NFT metadata in https://github.com/biznach/mymetapets/blob/main/Assets/Bizfish/Scripts/BizSchoolController.cs (Temporarily struggled to get loaded assets to align with AI objects) 

### Polygon

The "Genesis" ERC1155 NFT's have been minted on the Mumbai testnet of the Polygon blockchain with the intent of minting on mainnet when ready for public participation. 
The smart contract can be verified at https://mumbai.polygonscan.com/address/0x89bb19b45c8481d9d0a48be4b1287fbc54ee7506
The NFT collection can be viewd at https://testnets.opensea.io/collection/mymetapets

### Valist

Although the storefront presence is light, the game is proudly hosted on Valis.io at https://app.valist.io/mymetapets/mymetapets
You can look forward to robust metadata and compelling premium offerings

### Unity

Unity engine (and extensions) are used to build a WEBGL executable

### Chainlink

This feature has not yet been implemented, but it will ensure that all random functions have on-chain verification
