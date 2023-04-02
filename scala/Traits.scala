trait Composition {
  var composer: String

  def compose(): String
}

class Score(var composer: String) extends Composition {
  override def compose(): String = s"The score is composed by $composer"
}

// Extending Multiple Traits

trait SoundProduction {
  var engineer: String

  def produce(): String
}

class Score(var composer: String, var engineer: String)
  extends Composition with SoundProduction {

  override def compose(): String = s"The score is composed by $composer"

  override def produce(): String = s"The score is produced by $engineer"
}

// Extending a Trait in Another Trait 

trait Orchestration {
  var orchestra: String
}

trait Mixing {
  var mixer: String
}

trait Composition extends Orchestration with Mixing {
  var composer: String

  def compose(): String
}

class Score(var composer: String,
            var engineer: String,
            var orchestra: String,
            var mixer: String)
  extends Composition with SoundProduction {

  override def compose(): String =
    s"""The score is composed by $composer,
       |Orchestration by $orchestra,
       |Mixed by $mixer""".stripMargin

  override def produce(): String = s"The score is produced by $engineer"
}

// Adding a Trait to an Object Instance

trait Vocals {
  val sing: String = "Vocals mixin"
}

val score = new Score(composer, engineer, orchestra, mixer, 10) with Vocals
assertEquals(score.sing, "Vocals mixin")



