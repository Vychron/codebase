function updateEntry(thisName, num, t1, t2) {
  if (window.XMLHttpRequest) {
    xmlhttp = new XMLHttpRequest();
  } else {
    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
  }
  let controlScript = "updateSpecies.php";
  let httpString = controlScript + "?thisName=" + thisName + "&num=" + num + "&type1=" + t1 + "&type2=" + t2;
  let httpResponse = "";
  xmlhttp.open("GET", httpString, true);
  xmlhttp.send();
  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      httpResponse = xmlhttp.responseText;
    }
  }
}

function initialize(parent) {
  if (window.XMLHttpRequest) {
    xmlhttp = new XMLHttpRequest();
  } else {
    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
  }
  let controlScript = "initializer.php";
  let httpString = controlScript + "?parent=" + parent;
  let httpResponse = "";
  xmlhttp.open("GET", httpString, true);
  xmlhttp.send();
  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      httpResponse = xmlhttp.responseText;
    }
  }
}
