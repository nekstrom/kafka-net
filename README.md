kafka-net
=========

Native C# client for Kafka queue servers.  

License
-----------
Copyright 2014, James Roland under Apache License, V2.0. See LICENSE file.

Summary
-----------
This project is a .NET implementation of the [Apache Kafka] protocol.  The wire protocol portion is based on the [kafka-python] library writen by [David Arthur] and the general class layout attempts to follow a similar pattern as his project.  To that end, this project builds up from the low level KafkaConnection object for handling async requests to/from the kafka server, all the way up to a higher level Producer/Consumer classes.

Pieces of the Puzzel
-----------
##### Protocol
The protocol has been divided up into concrete classes for each request/response pair.  Each class knows how to encode and decode itself into/from their appropriate Kafka protocol byte array.  One benefit of this is that it allows for a nice generic send method on the KafkaConnection.

##### KafkaConnection
Provides async methods on a persistent connection to a kafka broker (server).  The send method uses the TcpClient send async function and the read stream has a dedicated thread which uses the correlation Id to match send requests to the correct response.

##### BrokerRouter
Provides metadata based routing of messages to the correct Kafka partition.  This class also manages the multiple KafkaConnections for each Kafka server returned by the broker section in the metadata request.  Routing logic is provided by the IPartitionSelector.

##### IPartitionSelector
Provides the logic for routing which partition the BrokerRouter should choose.  DefaultPartitionSelector will use round robin partition selection if the key property on the message is null and a mod/hash of the key value if present.

##### Producer
Provides a higher level class which uses the combination of the BrokerRouter and KafkaConnection to send batches of messages to a Kafka broker.

##### Consumer
Provides a higher level class which will consumer messages from a whitelist of partitions from a single topic.  The consumption mechanism is a blocking IEnumerable of messages.  If no whitelist is provided then all partitions will be consumed creating one KafkaConnection for each partition leader.



Status
-----------
The current version of this project is a functioning "work in progress" as it was only started in early February.  The wire protocol is complete except for Offset Commits to the servers (as there is a bug in 0.8.0 which prevents testing of this feature).  The library is functioning in that there is a complete Producer and Consumer class thus messages can pass to and from a Kafka server.  

##### The major items that needs work are:
* IOC for providing customization of internal behaviour of the base API. (right now the classes pass around option parameters)
* General structure of the classes is not finalized and breaking changes will occur.
* Compression of message sets is not currently implemented.  
* Offset Commits - central storage of offset progress.
* Currently only works with .NET Framework 4.5 as it uses the await command.
* nuget package.
* Test coverage.
* Documentation.

Comment
----------
This is a pet project for me and is not currently backed by a need for a Kafka server client.  Which means the client is only currently being tested against a small set of Kafka test servers and not against any server that has any real data load.  






[kafka-python]:https://github.com/mumrah/kafka-python
[Apache Kafka]:http://kafka.apache.org
[David Arthur]:https://github.com/mumrah