Feature: Genre Information API

Scenario: Retrieve all genres
Given a comprehensive database of genres
When the user requests information for all genres
Then all the available <Genres> should be returned with a status code <status>

Examples:
|                          Genres                              | status |
| [{id: 1, Name: "Drama"}, {id: 2, Name: "Comedy"}]            | 200    |
| [{id: 3, Name: "Horror"}, {id: 4, Name: "Sci-Fi"}]           | 200    |
| [{id: 5, Name: "Romance"}, {id: 6, Name: "Documentary"}]     | 200    |

Scenario: Fetch genre details by id
Given a comprehensive database of genres
When the user requests information for the genre with id <id>
Then the genre details <Genre> with status code <status> should be returned

Examples:
| id |               Genre               | status |
| 1  | {id: 1, Name: "Drama"}            | 200    |
| 2  | {id: 2, Name: "Comedy"}           | 200    |

Scenario: Add a new genre
Given a comprehensive database of genres
When the user adds a new genre with the details <NewGenre>
Then the new genre should be added, and a status code <status> should be returned

Examples:
|               NewGenre                | status |
| {id: 7, Name: "Thriller"}             | 201    |
| {id: 8, Name: "Fantasy"}              | 201    |

Scenario: Update an existing genre
Given a comprehensive database of genres
When the user updates the genre with the details <UpdatedGenre>
Then the genre should be updated, and a status code <status> should be returned

Examples:
|              UpdatedGenre              | status |
| {id: 1, Name: "Drama and Melodrama"}   | 200    |
| {id: 2, Name: "Comedy and Satire"}     | 200    |

Scenario: Remove an existing genre
Given a comprehensive database of genres
When the user deletes the genre with id <id>
Then the genre with id <id> should be removed, and a status code <status> should be returned

Examples:
| id | status |
| 1  | 200    |
| 3  | 200    |

