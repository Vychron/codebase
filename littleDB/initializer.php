<?php
  $parent = $_REQUEST['parent'];
  $file = 'entries.json';
  if (file_exists($file))
  {
    $filedata = file_get_contents($file);
    $objson = json_decode($filedata, true);
  }
  else echo $file . ' doesn\'t exist!';
  SORT_STRING($objson);
  echo $objson;

  $dom = new DOMDocument('1.0', 'utf8');
  $el = $dom->createElement('option', 'some value i guess');
  $parent->appendChild($el);
 ?>
