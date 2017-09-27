<html>

	<head>
		<link rel="stylesheet" type="text/css" href="FormStyles.css">
	</head>
	<body class="Background">
	
	
		<ul id='couleur'>
  <li><a  href="index.php">Home</a></li>
  <li><a  href="liste.php">News</a></li>
  <li><a  href="#contact">Contact</a></li>
  <li style="float:right"><a  href="Connexion.php">Connexion</a></li>
  </ul>

			
		<div>
		<form method="post">

		Nom: <br>
		<input type="text" placeholder="entrez votre pr&eacute;nom" name="nom"> <br>
		Ville: <br>
		<input type="text" placeholder="entrez votre ville" name="ville"> <br>
		Mot de passe: <br><br>
		<input type="text" placeholder="entrez votre mot de passe" name="mdp1"> <br>
	
		<input type="submit" name="soumettre">
		
		
			 <?php
			try
			{
				$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
			    
			   }
			 
			   catch (PDOException $e)
			{
			       echo('Erreur de connexion: ' . $e->getMessage());
			       
			       exit();
			        
			} 
			if(isset($_POST["soumettre"]))
			{
				
	
				$nom = $_POST["nom"]; 	
				$ville = $_POST["ville"];			
				$mdp1 = $_POST["mdp1"];
				$membre = 0;
				
				try
				{
					$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
				  	$stm = $bdd ->prepare("CALL InsertionClient(?,?,?,?)", array(PDO::ATTR_CURSOR, PDO::CURSOR_FWDONLY));

					
					
					
					$stm->bindParam(1, $nom);
					$stm->bindParam(2, $ville);
					$stm->bindParam(3, $membre);
					$stm->bindParam(4, $mdp1);
					
					// appel de la procÃ©dure stockÃ©e
					$stm->execute();
					
					
					 session_start();
							
					 $_SESSION["nom"] = $_POST["nom"];
					$_SESSION["mdp1"] = $_POST["mdp1"];
					$_SESSION['isLogged'] = true;
					header("Location:site.php");
					
						
					
					

					$stm->closeCursor();
					
				   }
				 
				   catch (PDOException $e)
				{
				       echo('Erreur de connexion: ' . $e->getMessage());
				       
				       exit();
				        
				} 

				
								
			}

			  
		 ?>	

		</form>
		</div>
		
		
	
					
	</body>
</html>