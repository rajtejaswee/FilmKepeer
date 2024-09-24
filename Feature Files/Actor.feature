Feature: Actor Information API

Scenario: Retrieve all actors' information
Given a comprehensive database of actors
And the user requests details for all actors
Then the <ActorDetails> should be returned with a status code <status>

Examples:
| ActorDetails                                                                                              | status |
| [{id: 1, Name: "John Doe", DOB: 05-15-1990, Gender: "Male", Bio: "Dramatic performer"}, {id: 2, Name: "Jane Smith", DOB: 12-22-1985, Gender: "Female", Bio: "Comedy specialist"}] | 200    |
| [{id: 3, Name: "Alice Johnson", DOB: 08-30-1977, Gender: "Female", Bio: "Romantic star"}, {id: 4, Name: "Bob Brown", DOB: 03-14-1965, Gender: "Male", Bio: "Action hero"}]         | 200    |

Scenario: Fetch details of a specific actor
Given a comprehensive database of actors
When the user requests information for the actor with id <id>
And an actor with id <id> exists in the database
Then <ActorInfo> and a status code <status> should be returned

Examples:
| id |                                      ActorInfo                                                           | status |
| 1  | {id: 1, Name: "John Doe", DOB: 05-15-1990, Gender: "Male", Bio: "Dramatic performer"}                     | 200    |
| 2  | {id: 2, Name: "Jane Smith", DOB: 12-22-1985, Gender: "Female", Bio: "Comedy specialist"}                  | 200    |

Scenario: Attempt to fetch a non-existent actor
Given a comprehensive database of actors
When the user requests information for the actor with id <id>
And an actor with id <id> does not exist in the database
Then a status code <status> should be returned

Examples:
| id  | status |
| -99 | 404    |

Scenario: Add a new actor to the database
Given a comprehensive database of actors
When the user adds a new actor with the details <NewActor>
Then the new actor should be added, and a status code <status> should be returned

Examples:
| NewActor                                                                                                | status |
| {id: 5, Name: "Michael King", DOB: 11-11-1992, Gender: "Male", Bio: "Thriller expert"}                   | 201    |
| {id: 6, Name: "Laura White", DOB: 06-25-1988, Gender: "Female", Bio: "Sci-fi enthusiast"}                | 201    |

Scenario: Update an existing actor's information
Given a comprehensive database of actors
When the user updates an actor's information with the new details <UpdatedActor>
Then the actor's information should be updated, and a status code <status> should be returned

Examples:
| UpdatedActor                                                                                             | status |
| {id: 1, Name: "John Doe", DOB: 05-15-1990, Gender: "Male", Bio: "Versatile actor"}                       | 200    |
| {id: 2, Name: "Jane Smith", DOB: 12-22-1985, Gender: "Female", Bio: "Award-winning comedian"}            | 200    |

Scenario: Delete an actor from the database
Given a comprehensive database of actors
When the user deletes the actor with id <id>
Then the actor with id <id> should be removed, and a status code <status> should be returned

Examples:
| id | status |
| 1  | 200    |
| 3  | 200    |

