Feature: Movie Management API

Scenario: Retrieve a movie with a valid ID
Given a collection of movies with unique IDs
When the user requests a movie with a valid movieID <id>
Then the <movie> details should be returned with a status code <status>

Examples:
| id |                                               movie                                                          | status |
| 1  | {id: 1, Name: "Interstellar", Genre: "Sci-Fi", Poster: "www.example.com/poster1", ProducerId: 1, Year: 2014} | 200    |
| 2  | {id: 2, Name: "Inception", Genre: "Thriller", Poster: "www.example.com/poster2", ProducerId: 2, Year: 2010}  | 200    |
| 3  | {id: 3, Name: "The Matrix", Genre: "Action", Poster: "www.example.com/poster3", ProducerId: 3, Year: 1999}   | 200    |
 
Scenario: User requests a movie with an invalid ID
Given a collection of movies with unique IDs
When the user requests a movie with an invalid movieID <id>
Then a status code <status> should be returned

Examples:
| id  | status |
| -1  | 404    |
| -99 | 404    |

Scenario: User uploads a new movie
Given there exists a collection of movies
And the user uploads a new movie with the details <newMovie>
Then the movie should be added, and a status code <status> should be returned

Examples:
|                                            newMovie                                                      | status |
| {id: 4, Name: "Avatar", Genre: "Fantasy", Poster: "www.example.com/poster4", ProducerId: 4, Year: 2009}  | 201    |
| {id: 5, Name: "Titanic", Genre: "Romance", Poster: "www.example.com/poster5", ProducerId: 5, Year: 1997} | 201    |

Scenario: User updates an existing movie
Given there exists a collection of movies
And the user updates a movie with the details <updatedMovie>
Then the movie should be updated, and a status code <status> should be returned

Examples:
|                                            updatedMovie                                                            | status |
| {id: 1, Name: "Interstellar", Genre: "Adventure", Poster: "www.example.com/newposter1", ProducerId: 1, Year: 2014} | 200    |
| {id: 2, Name: "Inception", Genre: "Mystery", Poster: "www.example.com/newposter2", ProducerId: 2, Year: 2010}      | 200    |

Scenario: User attempts to update a non-existing movie
Given there exists a collection of movies
And the user attempts to update a movie with the details <nonExistentMovie>
And the movie does not exist in the collection
Then a status code <status> should be returned

Examples:  
|                                            nonExistentMovie                                                | status |
| {id: -1, Name: "Unknown", Genre: "Unknown", Poster: "www.example.com/unknown", ProducerId: -1, Year: 2024} | 400    |
| {id: -2, Name: "Unknown", Genre: "Unknown", Poster: "www.example.com/unknown2", ProducerId: -2, Year: 2024}| 400    |

Scenario: User deletes an existing movie
Given there exists a collection of movies
And the user wants to delete a movie with id <id>
And the movie with id <id> exists
Then the movie with id <id> should be removed, and a status code <status> should be returned

Examples:
| id | status |
| 1  | 200    |
| 2  | 200    |

