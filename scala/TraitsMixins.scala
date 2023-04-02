import scala.collection.mutable.ArrayBuffer

//Abstract class IntQueue
abstract class IntQueue {
  def get(): Int 
  def put(x: Int)
}

// A BasicIntQueue implemented with an ArrayBuffer
class BasicIntQueue extends IntQueue {
  private val buf = new ArrayBuffer[Int]
  def get() = buf.remove(0)
  def put(x: Int) { buf += x }
}

// The Doubling stackable modification trait.
// super calls in a trait are dynamically bound.
trait Doubling extends IntQueue {
  abstract override def put(x: Int) { super.put(2 * x) }
}

trait Incrementing extends IntQueue {
  abstract override def put(x: Int) { super.put(x + 1) }
}

trait Filtering extends IntQueue {
  abstract override def put(x: Int) {
    if (x >= 0) super.put(x)
  }
}

// Mixing in a trait when instantiating with new
val queue = new BasicIntQueue with Doubling
queue.put(10)
queue.get()

// The order of mixins is significant, traits further to the 
// right take effect first.
val queue1 = (new BasicIntQueue with Incrementing with Filtering)
queue1.put(-1)
queue1.put(0)
queue1.put(1)
queue1.get() // 1
queue1.get() // 2

