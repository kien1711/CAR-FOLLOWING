/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.h
  * @brief          : Header for main.c file.
  *                   This file contains the common defines of the application.
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2022 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under BSD 3-Clause license,
  * the "License"; You may not use this file except in compliance with the
  * License. You may obtain a copy of the License at:
  *                        opensource.org/licenses/BSD-3-Clause
  *
  ******************************************************************************
  */
/* USER CODE END Header */

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __MAIN_H
#define __MAIN_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f1xx_hal.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */

/* USER CODE END Includes */

/* Exported types ------------------------------------------------------------*/
/* USER CODE BEGIN ET */

/* USER CODE END ET */

/* Exported constants --------------------------------------------------------*/
/* USER CODE BEGIN EC */

/* USER CODE END EC */

/* Exported macro ------------------------------------------------------------*/
/* USER CODE BEGIN EM */

/* USER CODE END EM */

void HAL_TIM_MspPostInit(TIM_HandleTypeDef *htim);

/* Exported functions prototypes ---------------------------------------------*/
void Error_Handler(void);

/* USER CODE BEGIN EFP */

/* USER CODE END EFP */

/* Private defines -----------------------------------------------------------*/
#define Reset_Pin GPIO_PIN_2
#define Reset_GPIO_Port GPIOA
#define Reset_EXTI_IRQn EXTI2_IRQn
#define encoder_phai_Pin GPIO_PIN_11
#define encoder_phai_GPIO_Port GPIOA
#define encoder_phai_EXTI_IRQn EXTI15_10_IRQn
#define encoder_phaiA12_Pin GPIO_PIN_12
#define encoder_phaiA12_GPIO_Port GPIOA
#define encoder_phaiA12_EXTI_IRQn EXTI15_10_IRQn
#define encoder_trai_Pin GPIO_PIN_4
#define encoder_trai_GPIO_Port GPIOB
#define encoder_trai_EXTI_IRQn EXTI4_IRQn
#define output_dc_trai_Pin GPIO_PIN_5
#define output_dc_trai_GPIO_Port GPIOB
#define encoder_traiB6_Pin GPIO_PIN_6
#define encoder_traiB6_GPIO_Port GPIOB
#define encoder_traiB6_EXTI_IRQn EXTI9_5_IRQn
#define output_dc_traiB7_Pin GPIO_PIN_7
#define output_dc_traiB7_GPIO_Port GPIOB
#define output_dc_phai_Pin GPIO_PIN_8
#define output_dc_phai_GPIO_Port GPIOB
#define ouput_dc_phai_Pin GPIO_PIN_9
#define ouput_dc_phai_GPIO_Port GPIOB
/* USER CODE BEGIN Private defines */

/* USER CODE END Private defines */

#ifdef __cplusplus
}
#endif

#endif /* __MAIN_H */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
