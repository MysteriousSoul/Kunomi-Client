# Kunomi-Client

## Description
Kunomi is a media player where multiple users can play the same media synchronously over the internet.

#### Connecting users
Kunomi uses the concept of rooms, which are essentially clients connected a server in a single shared space.

* To be able to connect to a room, you need to know the IP address and port of the server hosting the room. Upon launch of Kunomi Client, there are fields to enter this information, along with a username to uniquely identify each user.


#### Playing media
Kunomi will play local copies of the same media sourced from either identical copies on the hard drive, or through the net.

* Example 1: If each user stores a copy of Hagure Yuusha no Aesthetica Episode 1.mp4 in 'C:\anime\aesthetica', each client can play this file.
* Example 2: If the server broadcasts a command to play a file from a URL, 'awesome.com/videofiles/test.mp4', each client will independantly buffer the stream on their own internet connection.

To ensure playback is in-sync with every client, the playback state of each client will affect others. For example, if one user pauses, the same action will occur on the other clients. In addition,
there is an option to re-sync the room if an unreasonable amount of delay occurs.

## Current Development
The current implementation of this software is experimental, and subject to change greatly. Local re-sync (resyncing your own client to others, instead of the entire room) is not yet finished in implementation.
