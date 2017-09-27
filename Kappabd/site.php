<html>

	<head>
	<link rel="stylesheet" type="text/css" href="FormStyles.css">
	<link rel="stylesheet" href="Style.css">
		<?php
			session_start();
			if(!$_SESSION['isLogged'])
			{
			  echo "Vous devez etre connecter pour acceder a cette partie du site."; 
			  header("Location:gtfo.php"); 
			}
		?>
		
	</head>
	<body class="Background">
	
	<ul id='couleur'>
	  <li><a  href="index.php">Spectacle</a></li>
	  <li><a  href="liste.php">News</a></li>
	  <li><a  href="#contact">Contact</a></li>
	  <li style="float:right"><a  href="#Compte"><?php echo "Bienvenue : ".$_SESSION['nom'];?></a></li>
  	</ul>

	<h1> 
		
		<?php
			echo "Bienvenue : ".$_SESSION['nom'];
		?>
	</h1>
	
	</body>
</html>