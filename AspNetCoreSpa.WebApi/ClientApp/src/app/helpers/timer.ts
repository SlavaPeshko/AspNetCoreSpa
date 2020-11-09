import { SendingSmsType } from '../models/SengingSmsType';


function startTimer( model: {timeLeft: number, type: SendingSmsType }) {
    const firstValue = model.timeLeft;
    model.type = SendingSmsType.TIMER;

    const interval = setInterval(() => {
      if(model.timeLeft > 0) {
        model.timeLeft--;
      } else {
        model.timeLeft = firstValue;
        model.type = SendingSmsType.RESEND;
        clearInterval(interval);
      }
    }, 1000)
  }

export { startTimer };