/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
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

/* Includes ------------------------------------------------------------------*/
#include "main.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "string.h"
#include "stdio.h" 
#include "stdlib.h"
#include "stdbool.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

#define pi 3.1415
#define SampleTime 0.01
#define van_toc 0.2    // phan tram %
#define Kp 0.23251
#define Ki 3.34671
#define d 1			// khoang cach tu xe -> human    d: 1 - 2 m
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
TIM_HandleTypeDef htim2;
TIM_HandleTypeDef htim3;

UART_HandleTypeDef huart1;

/* USER CODE BEGIN PV */
uint32_t CntTmp;
float RealVel_phai, RealVel_trai;
uint16_t CntVel_phai, CntVel_trai, HILIM, LOLIM;
uint16_t tick = 0, count = 0;
uint8_t pwm_phai , pwm_trai;

bool run = false;
float Real_Speed_left,Real_Speed_right,DesiredSpeed, van_toc_phai, van_toc_trai, DesiredSpeed_phai, DesiredSpeed_trai;
uint16_t time;

volatile uint8_t uartDataReady = 0;
volatile uint8_t Rx_Buffer[30];
volatile uint8_t Rx_indx = 0;
float distance = 0.0, distance_phai, distance_trai ;
uint8_t txData = '1';
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_TIM2_Init(void);
static void MX_TIM3_Init(void);
static void MX_USART1_UART_Init(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
#ifdef __GNUC__
	#define PUTCHAR_PROTOTYPE int __io_putchar(int ch)
#else 
	#define PUTCHAR_PROTOTYPE int fputc(int ch, FILE *f)
	#define GETCHAR_PROTOTYPE int fgetc(FILE *f)
#endif 
	PUTCHAR_PROTOTYPE
	{
		HAL_UART_Transmit(&huart1, (uint8_t*)&ch,1,100);
		return ch;
	}
	
void removeChars(char* str, char c) 
{
    int len = strlen(str);
    int i, j;

    for (i = 0, j = 0; i < len; i++)      // CHAY QUA TUNG KY TU VA KIEM TRA KY TU CAN XOA 
		{
        if (str[i] != c)   //   vi tri i khac ky tu can xoa
				{
            str[j++] = str[i];
        }
    }
    str[j] = '0';   // KIEN BUI , REMOVECHAR(K) - > IEN BUI
}	
void di_thang()
	{
		van_toc_phai=van_toc_trai=van_toc;
		
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_7, GPIO_PIN_SET);    //dc trai
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_5, GPIO_PIN_RESET);
						
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_9, GPIO_PIN_RESET);   // dc phai
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_8, GPIO_PIN_SET);
	}
void queo_trai()
	{
		van_toc_trai = van_toc/2.0; van_toc_phai=van_toc;	
	}
void queo_phai()
	{
		van_toc_phai = van_toc/2.0; van_toc_trai=van_toc;
	}
void di_lui()
	{
		van_toc_phai=van_toc_trai=van_toc;
		
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_5, GPIO_PIN_SET);
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_7, GPIO_PIN_RESET);
		
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_8, GPIO_PIN_RESET);
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_9, GPIO_PIN_SET);		
	}	

void stop()
	{	
		van_toc_phai=van_toc_trai=0.0;
	}

void trai_lui()
{											
	HAL_GPIO_WritePin(GPIOB, GPIO_PIN_7, GPIO_PIN_RESET);    //dc trai quay nguoc chieu
	HAL_GPIO_WritePin(GPIOB, GPIO_PIN_5, GPIO_PIN_SET);	
}
void phai_lui()
{						
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_9, GPIO_PIN_SET);   // dc phai
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_8, GPIO_PIN_RESET);	
}
void phai_thang()
{						
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_9, GPIO_PIN_RESET);   // dc phai
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_8, GPIO_PIN_SET);	
}
void trai_thang()
{
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_7, GPIO_PIN_SET);    //dc trai
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_5, GPIO_PIN_RESET);
}
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
	{

		if(huart->Instance == USART1) //uart1
		{		
				if(Rx_indx<29)	
				{			//HAL_UART_Transmit(&huart1, &txData, 1, HAL_MAX_DELAY);
					if(uartDataReady==0 )   //uart dang khong xu ly du lieu ,&& Rx_Buffer[0] == '@' && Rx_Buffer[1] != '@' 
					{			
                        if (Rx_Buffer[Rx_indx]=='#' )    // b'100.0,80.0#'  // 13 ky  tu -> Rx_indx = 0-12
							{
								if(Rx_Buffer[3]==',')
									{
										if(Rx_Buffer[0]!='-')
												{Rx_Buffer[0]='0';}
									}
								uartDataReady=1;
							}
						else
							{	
								Rx_indx++;
								HAL_UART_Receive_IT(&huart1,&Rx_Buffer[Rx_indx],1);		//vi tri cua ham` nay` la QUAN TRONG
							}
					}	
				}
				else
					Rx_indx=0;
		}
	}	
	
	
void process_uart()
{
								Rx_Buffer[Rx_indx] = '\0';
								//removeChars(Rx_Buffer, '@');
									//100.0,80.0#	
									//Rx_Buffer[0]=0;
									   //set cho Rx-Buffer co ket thuc la Null ("\0")   //12-4
									//distance = atof((char*)Rx_Buffer); //convert Rx_Buffer from string to float
								
									// Extract RPM values for each wheel
									char* token;
									token = strtok((char*)Rx_Buffer, ",");
									if (token != NULL) 
									{
										if(token[0]=='-'||token[1]=='-')  // neu gia tri dau tien la am
											{
												//removeChars(token,'-');
												token[0] = '0';
												phai_lui();		
												//distance_phai = atof(token);
												DesiredSpeed_phai = atof(token);
											}
										else
											{
												phai_thang();
												//distance_phai = atof(token);	
												DesiredSpeed_phai = atof(token);
											}
									
										token = strtok(NULL, ",");
										if (token != NULL) 
										{
											if(token[0]=='-')
												{
													token[0] = '0';
													trai_lui();
													//distance_trai = atof(token);
													DesiredSpeed_trai = atof(token);
												}
											else
												{
													trai_thang();
													//distance_trai = atof(token);	
													DesiredSpeed_trai = atof(token);
												}
										}
								}
									
								Rx_indx=0;
								uartDataReady=0;
								
							  HAL_UART_Receive_IT(&huart1,&Rx_Buffer[Rx_indx],1);
								HAL_UART_Transmit(&huart1, &txData, 1, HAL_MAX_DELAY);
								//Rx_indx=0;
						
}	
int PIDCtrl(float Desied, float Current , float p_coef, float i_coef)
{
		static float err_p = 0;
		static float iterm_p = 0;
		static float	err_sat = 0;
		static float	dterm_f_p = 0;
	
		float err, err_windup ;
		float pterm, iterm;
		float pidterm, pid_sat;
		uint16_t pidout ;
	
	HILIM = 99; LOLIM = 0;
	
	err	= Desied - Current;
	
	pterm = p_coef*err;
	//err_windup = i_coef*err + Kb*err_sat;
	iterm = iterm_p + Ki*err*SampleTime;
	
	iterm_p = iterm;
	err_p = err;
	
	pidterm = pterm  + iterm;   // just PI
	
	//Saturation of PIDterm   (bao~ hoa`)
	if (pidterm > HILIM)
		pidterm = HILIM;
	else if (pidterm <LOLIM)
		pidterm = LOLIM;
	
	//err_sat = pid_sat - pidterm;
	pidout = (uint16_t)pidterm;
	return pidout;
}
void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin)
	{
		if(GPIO_Pin == GPIO_PIN_4)
			{
					CntVel_trai++;
			}
		else if(GPIO_Pin == GPIO_PIN_6)
			{
					CntVel_trai++;
			}
		if(GPIO_Pin == GPIO_PIN_11)
			{
					CntVel_phai++;
			}
		else if(GPIO_Pin == GPIO_PIN_12)
			{
					CntVel_phai++;
			}
	}

void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)   
	{
//		run = true;
//		di_thang();
		
		if(htim->Instance==TIM2) 				// 1ms xay ra ngat
			{
				tick++;
				count++;
				run=true;
				if((tick > 9) && (run == true)) 		// tinh toan van toc moi~ 10ms
 					{
						tick = 0;
						//tính toán toc do rpm cho bieu do C#
						CntTmp = CntVel_phai;   // ppm counter from encoder
						CntVel_phai = 0;
						RealVel_phai = CntTmp*1000.0*60.0/(10.0*19.2*12.0*4.0);	//100/11 ;   // RPM
						
						CntTmp = CntVel_trai;   // ppm counter from encoder
						CntVel_trai = 0;
						RealVel_trai = CntTmp*1000.0*60.0/(10.0*19.2*12.0*4.0);	//100/11 ;   // RPM
						
						
			//-------------- PID dieu chinh toc do cho dong co -----------------------------------
					
//						van_toc = 0.1 ;
//						DesiredSpeed_phai = van_toc_phai*60.0*2.0/(0.145*pi);
//						DesiredSpeed_trai = van_toc_trai*60.0*2.0/(0.145*pi);
						

			
						pwm_phai = PIDCtrl(DesiredSpeed_phai, RealVel_phai, Kp, Ki);  //phan tram %
						__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_3, pwm_phai);   
						
						pwm_trai = PIDCtrl(DesiredSpeed_trai, RealVel_trai, Kp, Ki);  //phan tram %
						__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_4, pwm_trai);
					
//						Real_Speed_left = (RealVel_trai*0.145*pi)/(60.0*2.0);     // m/s    // van toc m/s dua tren so rpm
//						Real_Speed_right = (RealVel_phai*0.145*pi)/(60.0*2.0);		// m/s
						
					}
				if((run == true) && (count > 9))   // sau 10ms se gui Velocity 1 lan
					{
						printf("%.2f\r \n", RealVel_trai);
						//printf("%.2f\r \n", RealVel_phai);
						count = 0;						
					}
				
				if(run == false)   //stop dong co
					{
						stop();
					}
				
			}	
			
	}
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */
  

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
	HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_TIM2_Init();
  MX_TIM3_Init();
  MX_USART1_UART_Init();
  /* USER CODE BEGIN 2 */
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_3);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_4);
	HAL_TIM_Base_Start_IT(&htim2);      //start to timer 2 interrupt
	HAL_UART_Receive_IT(&huart1,&Rx_Buffer[Rx_indx],1);	
	HAL_UART_Transmit(&huart1, &txData, 1, HAL_MAX_DELAY);
  /* USER CODE END 2 */
	stop();
  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
	
  while (1)
  {
		
    /* USER CODE END WHILE */
			
					if (uartDataReady) 
					{
							process_uart();
					}	
								//HAL_UART_Transmit(&huart1, &txData, 1, HAL_MAX_DELAY);

					if(DesiredSpeed_trai > 100 || DesiredSpeed_phai > 100)
						{
									DesiredSpeed_trai = DesiredSpeed_phai =70;
						}		
    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
		return 0;	
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Initializes the CPU, AHB and APB busses clocks 
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.HSEPredivValue = RCC_HSE_PREDIV_DIV1;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL6;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB busses clocks 
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_1) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief TIM2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM2_Init(void)
{

  /* USER CODE BEGIN TIM2_Init 0 */

  /* USER CODE END TIM2_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM2_Init 1 */

  /* USER CODE END TIM2_Init 1 */
  htim2.Instance = TIM2;
  htim2.Init.Prescaler = 2399;
  htim2.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim2.Init.Period = 19;
  htim2.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim2.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim2) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim2, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim2, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM2_Init 2 */

  /* USER CODE END TIM2_Init 2 */

}

/**
  * @brief TIM3 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM3_Init(void)
{

  /* USER CODE BEGIN TIM3_Init 0 */

  /* USER CODE END TIM3_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};
  TIM_OC_InitTypeDef sConfigOC = {0};

  /* USER CODE BEGIN TIM3_Init 1 */

  /* USER CODE END TIM3_Init 1 */
  htim3.Instance = TIM3;
  htim3.Init.Prescaler = 78;
  htim3.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim3.Init.Period = 99;
  htim3.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim3.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim3) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim3, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&htim3) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim3, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  if (HAL_TIM_PWM_ConfigChannel(&htim3, &sConfigOC, TIM_CHANNEL_3) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_ConfigChannel(&htim3, &sConfigOC, TIM_CHANNEL_4) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM3_Init 2 */

  /* USER CODE END TIM3_Init 2 */
  HAL_TIM_MspPostInit(&htim3);

}

/**
  * @brief USART1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART1_UART_Init(void)
{

  /* USER CODE BEGIN USART1_Init 0 */

  /* USER CODE END USART1_Init 0 */

  /* USER CODE BEGIN USART1_Init 1 */

  /* USER CODE END USART1_Init 1 */
  huart1.Instance = USART1;
  huart1.Init.BaudRate = 115200;
  huart1.Init.WordLength = UART_WORDLENGTH_8B;
  huart1.Init.StopBits = UART_STOPBITS_1;
  huart1.Init.Parity = UART_PARITY_NONE;
  huart1.Init.Mode = UART_MODE_TX_RX;
  huart1.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart1.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART1_Init 2 */

  /* USER CODE END USART1_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOD_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOB, output_dc_trai_Pin|output_dc_traiB7_Pin|output_dc_phai_Pin|ouput_dc_phai_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pins : encoder_phai_Pin encoder_phaiA12_Pin */
  GPIO_InitStruct.Pin = encoder_phai_Pin|encoder_phaiA12_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_IT_RISING_FALLING;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : encoder_trai_Pin encoder_traiB6_Pin */
  GPIO_InitStruct.Pin = encoder_trai_Pin|encoder_traiB6_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_IT_RISING_FALLING;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

  /*Configure GPIO pins : output_dc_trai_Pin output_dc_traiB7_Pin output_dc_phai_Pin ouput_dc_phai_Pin */
  GPIO_InitStruct.Pin = output_dc_trai_Pin|output_dc_traiB7_Pin|output_dc_phai_Pin|ouput_dc_phai_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

  /* EXTI interrupt init*/
  HAL_NVIC_SetPriority(EXTI4_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(EXTI4_IRQn);

  HAL_NVIC_SetPriority(EXTI9_5_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(EXTI9_5_IRQn);

  HAL_NVIC_SetPriority(EXTI15_10_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(EXTI15_10_IRQn);

}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */

  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{ 
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     tex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

