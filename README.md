# Games Y'all Application Documentation
This is currently hosted on https://thecoby.itch.io/fantastic-arcade-application and built in unity using webGL. The answers are submitted to a [Google Form](https://docs.google.com/forms/d/e/1FAIpQLSfDJNpD4i9wjwFAN9bUW2uOkHZKhAxrg33g_NcyuBD7pnqgWg/viewform). The description data used lives in the [Fantastic Arcade Skills And Roles Google Sheet](https://docs.google.com/spreadsheets/d/1FlsUJh17W3YaHkOzgUt7vtivutaww21FCxyiJm0j4gA/edit#gid=0) (although this must be [manually imported](#importing-roles-and-skill-descriptions)).
## Adding new Skills
New skills must be added in unty as new scriptable objects. To add a new role or skill open the appropriate folder:

`...Assets\Resources\ScriptableObjects\Skills`

Duplicate an existing skill `(Ctrl+D)` and then rename the file itself. Renaming the file will automatically update the skill name.

New skills must then be added into the [Fantastic Arcade Skills And Roles Google Sheet](https://docs.google.com/spreadsheets/d/1FlsUJh17W3YaHkOzgUt7vtivutaww21FCxyiJm0j4gA/edit#gid=0) that is used to ensure spelling and syntax in the file. [This file must then be added to the project.](#importing-roles-and-skill-descriptions)


{% hint style="danger" %}
Do not modify any of the fields in a skill of the name and description.
{% endhint %}

## Adding new Roles
New roles must be added in unty as new scriptable objects. To add a new role or skill open the appropriate folder:
`...Assets\Resources\ScriptableObjects\Roles`

Duplicate an existing role `(Ctrl+D)` and then rename the file itself. Renaming the file will automatically update the role name.
## Importing Roles and Skill descriptions
To import descriptions the [role](#adding-new-roles) or [skill](#adding-new-skills) must first be added to the unity project.

{% hint style="danger" %}
If roles are skills are added to the spreadsheet without first being added to the unity project they will **not** show up.
{% endhint %}

From there the new role or skill must be added to the [Fantastic Arcade Skills And Roles Google Sheet](https://docs.google.com/spreadsheets/d/1FlsUJh17W3YaHkOzgUt7vtivutaww21FCxyiJm0j4gA/edit#gid=0). This is CaSe SeNsItIvE! Once the role or skill has been added to the sheet the description can be updated at will. Once all descriptions are in a point you are happy with you will want to export the file to csv.

`File > Download > Comma Separated Values (.csv)`

From there you have to convert the csv file into a Json. So far I've used https://csvjson.com/csv2json for this. After that point you want to add the file into the Resources folder of Unity replacing the old csv.

`...Assets/Resources/JsonData/csvjson.json`

{% hint style="danger" %}
If the old .csv is not replaced the import may give fucky results!
{% endhint %}

From there you want to update descriptions `Edit > Update Descriptions` (this is at the very bottom of the edit menu). The descriptions should now be updated and ready for use!