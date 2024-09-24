Feature: Producers API

Scenario: Retrieve all producers
Given a comprehensive database of producers
When the user requests information for all the producers
Then all the <Producers> should be returned with a status code <status>

Examples:
|                         Producers                                                       | status |
| [{id: 1, Name: "Christopher", DOB: "1970-07-30", Sex: "Male", Bio: "Drama Specialist"}] | 200    |
| [{id: 2, Name: "Nina", DOB: "1985-04-12", Sex: "Female", Bio: "Documentary Expert"}]    | 200    |

Scenario: Retrieve producer details with a valid ID
Given a comprehensive database of producers
When the user requests information for the producer with id <id>
And the producer with id <id> exists
Then the <Producer> details with a status code <status> should be returned

Examples:
| id |               Producer                                                                | status |
|  1 | {id: 1, Name: "Christopher", DOB: "1970-07-30", Sex: "Male", Bio: "Drama Specialist"} | 200    |
|  2 | {id: 2, Name: "Nina", DOB: "1985-04-12", Sex: "Female", Bio: "Documentary Expert"}    | 200    |

Scenario: Retrieve producer details with an invalid ID
Given a comprehensive database of producers
When the user requests information for the producer with id <id>
And the producer with id <id> does not exist
Then a status code <status> should be returned

Examples:
| id  | status |
| -1  | 404    |
| -99 | 404    |

