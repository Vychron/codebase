<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
    <meta charset="utf-8">
    <title>Little DataBase</title>
    <link rel="stylesheet" href="style.css">
  </head>
  <body>
    <fieldset>
      <legend><h1>Current information</h1></legend>
      <table>
        <tr>
          <td><h3>Name</h3></td>
          <td><input type="text" id="thisName" name="" value="" placeholder="Name"/></td>
          <td><button type="button" id="addName" name="button">Update</button></td>
        </tr>
        <tr>
          <td><h3>Number</h3></td>
          <td><input type="text" id="thisNum" name="" value="" placeholder="No."/></td>
        </tr>
        <tr>
          <td><h3>Type(s)</h3></td>
          <td>
            <select id="type1">
              <option value="Normal" selected="selected">Normal</option>
            </select>
            <select id="type2">
              <option value="None" selected="selected">--None--</option>
            </select>
          </td>
        </tr>
      </table>
      <h3>Evolves into...</h3>
      <div id="evolutions">
      </div>
      <br>
      <button type="button" id="add-new">Add New...</button>
    </fieldset>
    <script src="ajax.js" charset="utf-8"></script>
    <script>
      var thisName;
      var parent;
      const fetch = document.getElementById('add-new');
      fetch.addEventListener('click', function() {
        parent = document.getElementById('type1');
        initialize(parent);
      });
      const btn = document.getElementById('addName');
      btn.addEventListener('click', function() {
        thisName = document.getElementById('thisName').value;
        num = document.getElementById('thisNum').value;
        updateEntry(thisName, num, type1.value, type2.value);
      });
    </script>

    <script src="types.js" charset="utf-8"></script>
    <script src="script.js" charset="utf-8"></script>
  </body>
</html>
