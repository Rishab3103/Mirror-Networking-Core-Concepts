# Mirror-Networking-Core-Concepts
Implementation of the core concepts of the Mirror Networking Tool for Unity

# Core Concepts:
# Hosting
1. Host(Server + Client): Allows a user to act as both client and server.
2. Host(Server)
3. Host(Client)

# Authority:
1. Server has authority over all objects unless specified otherwise
2. Client authority can be activated
3. Authority can be transferred or revoked.

# Data Synchronization
1. Command: Commands are called from client and run on servers.
2. ClientRPC: Server uses remote procedure calls to run on clients.
3. TargetRPC: Server uses remote procedure calls to run on specific clients
4. SyncVars: Aids in synchronization of variables across all clients. Can be only called from server.

# What this repository implements:
1. Basic Hosting: You can join the network as Server + Client or just server and have another instance join as a client.
2. Player Spawning: Each instance spawns a player in the room (Server + Client) which can be controlled by the specific instance only.
3. Implementation of Command, ClientRPC,TargetRPC and Sync Vars.
4. To get the Debug Logs, ParrelSyn has be used, which creates a clone of the Unity Editor.
