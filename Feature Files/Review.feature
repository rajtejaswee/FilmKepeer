Feature: Reviews API

Scenario: Retrieve all reviews for a specific movie
Given an existing database of movie reviews
When the user requests reviews for a movie with movieId <movieId>
Then all the reviews <Reviews> for the movie should be returned with status code <status>

Examples:
| movieId |                               Reviews                                                     | status |
|   1     | [{id: 1, movieId: 1, review: "Great visuals", rating: 4}, {id: 2, movieId: 1, review: "Average", rating: 3}] | 200    |
|   2     | [{id: 3, movieId: 2, review: "Outstanding!", rating: 5}, {id: 4, movieId: 2, review: "Not my taste", rating: 2}] | 200    |

Scenario: User adds a new review
Given an existing database of movie reviews
When the user wants to submit a new review with details <Review>
Then the new review should be added to the database and a status code <status> should be returned

Examples:
|                          Review                                                     | status |
| {id: 1, movieId: 1, review: "Fantastic storyline!", rating: 5}                      | 201    |
| {id: 2, movieId: 2, review: "Didn't like the ending", rating: 2}                    | 201    |

Scenario: User updates an existing review
Given an existing database of movie reviews
When the user wants to update a review with new details <Review>
Then the review should be updated with the provided information and a status code <status> should be returned

Examples:
|                          Review                                                     | status |
| {id: 1, movieId: 1, review: "Fantastic storyline!", rating: 5}                      | 200    |
| {id: 2, movieId: 2, review: "Didn't like the ending", rating: 2}                    | 200    |

Scenario: User deletes an existing review
Given an existing database of movie reviews
When the user requests to delete a review with id <reviewId>
Then the review with id <reviewId> should be removed from the database and a status code <status> should be returned

Examples:
| reviewId | status |
|     1    | 200    |
|     2    | 200    |

