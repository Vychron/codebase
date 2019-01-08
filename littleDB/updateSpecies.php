<?php
  $nameValue = $_REQUEST['thisName'];
  $num = $_REQUEST['num'];
  $t1 = $_REQUEST['type1'];
  $t2 = $_REQUEST['type2'];
  $file = 'json/species.json';

  if (file_exists($file))
  {
    $filedata = file_get_contents($file);
    $objson = json_decode($filedata, true);
  }
  else echo $file . ' doesn\'t exist!';

  $objson[$nameValue]['Entry Number'] = $num;
  $objson[$nameValue]['Type 1'] = $t1;
  $objson[$nameValue]['Type 2'] = $t2;

  writeJson($objson, $file);

  function writeJson($objson, $fileOutput){
    $saveJson = json_encode($objson);
    $file = fopen($fileOutput, "w") or die ("can't open file");
    fwrite($file, $saveJson);
    fclose($file);
}
?>
