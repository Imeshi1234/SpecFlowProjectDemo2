Feature: Create, Edit and Delete TM record

Scenario: Create a TM record
Given user logs into TurnUp Portal
And user navigates to time and material page
When user creates a new time and material record
Then turnup portal should save the new time and material record

Scenario: Edit a TM record
Given user logs into TurnUp Portal
And user navigates to time and material page
When user edits an existing time and material record
Then turnup portal should save the existing time and material record

Scenario: Delete a TM record
Given user logs into TurnUp Portal
And user navigates to time and material page
When user delete an existing time and material record
Then turnup portal should delete the existing time and material record
